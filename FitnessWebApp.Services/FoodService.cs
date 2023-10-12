namespace FitnessWebApp.Services
{
    using Microsoft.EntityFrameworkCore;

    using FitnessWebApp.Models.Models;
    using FitnessWebApp.Services.Interfaces;
    using FitnessWebApp.Web.Data;
    using FitnessWebApp.Web.ViewModels.Enums;
    using FitnessWebApp.Web.ViewModels.Models.Food;
    using FitnessWebApp.Web.ViewModels.Models.GymUser;
    public class FoodService : IFoodService
    {
        private readonly FitnessAppDbContext dbContext;
        public FoodService(FitnessAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(AddFoodViewModel model)
        {
            Food food = new Food()
            {
                Name = model.Name,
                Protein = model.Protein,
                Carbs = model.Carbs,
                Fat = model.Fat,
            };
            await dbContext.AddAsync(food);
            await dbContext.SaveChangesAsync();
        }
        public async Task<AllFoodsAndFiltredViewModel> AllAsync(AllFoodsQueryModel queryModel)
        {
            IQueryable<Food> foodQuery = dbContext
                .Foods
                .Where(f => f.EatingTime.HasValue == false)
                .Distinct()
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                foodQuery = foodQuery
                    .Where(f => EF.Functions.Like(f.Name, wildCard));
            }

            foodQuery = queryModel.FoodSorting switch
            {
                FoodSorting.HighAtProtein => foodQuery
                    .OrderByDescending(f => f.Protein),                    
                FoodSorting.LowCarb => foodQuery
                    .OrderBy(f => f.Carbs),
                FoodSorting.LowCalories => foodQuery
                .OrderBy(f=>(f.Carbs*4)+(f.Protein*4)+f.Fat*9),
                FoodSorting.LowFat => foodQuery
                    .OrderBy(f => f.Fat),
                FoodSorting.NameDescending => foodQuery
                    .OrderByDescending(f => f.Name),
                FoodSorting.NameAscending => foodQuery
               .OrderBy(f => f.Name),
                _ => foodQuery
                    .OrderByDescending(h => h.Name)
            };

            IEnumerable<MineFoodsViewModel> allFoods = await foodQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.FoodsPerPage)
                .Take(queryModel.FoodsPerPage)
                .Select(h => new MineFoodsViewModel
                {
                    Carbs = h.Carbs,
                    Fat = h.Fat,
                    Protein = h.Protein,
                    Grams = h.Grams.HasValue ? h.Grams.Value : 0,
                    Name = h.Name,
                })
                
                .Distinct()
                .ToArrayAsync();

            int totalFoods = await foodQuery.CountAsync();

            return new AllFoodsAndFiltredViewModel()
            {
                TotalFoodCount = totalFoods,
                Foods = allFoods
            };
        }


        public async Task<int> GetFoodIdByFoodNameAsync(string name)
        {
            Food food = await dbContext.Foods.FirstAsync(f => f.Name == name);
            return food.FoodId;
        }
    }
}
