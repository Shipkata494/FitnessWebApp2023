namespace FitnessWebApp.Services
{
    using Microsoft.EntityFrameworkCore;

    using FitnessWebApp.Common.Exceptions;
    using FitnessWebApp.Data.Models.Models;
    using FitnessWebApp.Models.Models;
    using FitnessWebApp.Services.FormModels.GymUser;
    using FitnessWebApp.Services.Interfaces;
    using FitnessWebApp.Web.Data;
    using FitnessWebApp.Web.ViewModels.Models.GymUser;
    using FitnessWebApp.Web.ViewModels.Models.Food;
    using FitnessWebApp.Web.ViewModels.Models.Activities;

    public class GymUserService : IGymUserService
    {
        private readonly FitnessAppDbContext dbContext;
        private readonly IPartOfDayService partOfDayService;
        private readonly IFoodService foodService;

        public GymUserService(FitnessAppDbContext _dbContext, IPartOfDayService _partOfDayService, IFoodService _foodService)
        {
            dbContext = _dbContext;
            partOfDayService = _partOfDayService;
            foodService = _foodService;
        }
        public async Task<IEnumerable<ActivitiesSelectionViewModel>> AllActivitiesAsync()
        {
           return await dbContext.Activities.Select(a => new ActivitiesSelectionViewModel()
            {
                Id = a.Id,
                Name = a.Name,
            }).ToListAsync();
        }

        public async Task<bool> GymUserExistsByUserIdAsync(string? userId)
        {
            return await dbContext.GymUsers.AnyAsync(gu => gu.UserId.ToString() == userId);
        }
        public async Task AddGymUserAsync(string userId, BecomeGymUserFormModel model)
        {

            GymUser user = new GymUser()
            {
                UserId = Guid.Parse(userId),
                Weight = model.Weight,
                Height = model.Height,
                Age = model.Age,
                Sex = model.Sex,
                Activiti = await dbContext.Activities.FirstOrDefaultAsync(a=>a.Id == model.ActivitiId)
            };
            await dbContext.GymUsers.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task<string> GetUserIdAndReturnGymUserIdAsync(string userId)
        {
            var user = await dbContext.GymUsers.FirstOrDefaultAsync(gu => gu.UserId.ToString() == userId);
            if (user == null)
            {
                throw new UserNotFoundExeption();
            }
            return user.GymUserId.ToString();
        }

        public async Task AddFoodInFoodsCollectionAsync(string userId, DiaryUserFormModel model)
        {
            FoodSelectPartOfDayFormModel formModel = await partOfDayService.PartOfDaysAsync(model.PartId);
            GymUser? user = await dbContext.GymUsers.FirstOrDefaultAsync(gu => gu.UserId.ToString() == userId);
            if (user == null)
            {
                throw new GymUserDoesNotExistException();
            }

            PartOfDay partOfDay = new PartOfDay()
            {
                Id = formModel.Id,
                Name = formModel.Name
            };

            Food? searchFood = await dbContext.Foods.FirstOrDefaultAsync(f => f.Name == model.Name);
            if (searchFood == null)
            {
                throw new FoodDoesNotExistException();
            }
            else
            {

                AddFoodInFoodsCollectionFormModel foodModel = new AddFoodInFoodsCollectionFormModel()
                {
                    Id = searchFood.FoodId,
                    Name = searchFood.Name,
                    Fat = searchFood.Fat,
                    Carbs = searchFood.Carbs,
                    Protein = searchFood.Protein
                };

                Food food = new Food()
                {
                    Fat = foodModel.Fat,
                    Name = foodModel.Name,
                    PartOfDayId = model.PartId,
                    Carbs = foodModel.Carbs,
                    Protein = foodModel.Protein,
                    EatingTime = model.Date,
                    Grams = model.Grams
                };
                GymUsersFoods usersFoods = new GymUsersFoods()
                {
                    Food = food,
                    GymUser = user,
                };
                food.GymUsersFoods.Add(usersFoods);
                await dbContext.Foods.AddAsync(food);
                await dbContext.GymUsersFoods.AddAsync(usersFoods);
                await dbContext.SaveChangesAsync();



            }
        }

        public async Task<MineFoodsQueryModel> MineFoodsAsync(MineFoodsQueryModel queryModel, string userId)
        {
            GymUser? user = await dbContext.GymUsers.FirstOrDefaultAsync(gu => gu.UserId.ToString() == userId);
            if (user == null)
            {
                throw new UserNotFoundExeption();
            }
            var gymUsersQuery = dbContext
                 .GymUsersFoods
                 .Include(f => f.Food)
                 .Where(f => f.GymUser.GymUserId.ToString().ToLower() == user.GymUserId.ToString()!.ToLower())
                 .AsQueryable();

            gymUsersQuery =  gymUsersQuery.Where(gu => gu.Food.EatingTime.HasValue && gu.Food.EatingTime.Value.Day == queryModel.Day.Day);
          

            var AllMyneFoodsQueryModel =
             await
              gymUsersQuery
             .Select(f => new MineFoodsViewModel
             {
                 Name = f.Food.Name,
                 Carbs = f.Food.Carbs,
                 Protein = f.Food.Protein,
                 Fat = f.Food.Fat,
                 DateTime = f.Food.EatingTime.HasValue ? f.Food.EatingTime.Value : DateTime.UtcNow,
                 Grams = f.Food.Grams.HasValue ? f.Food.Grams.Value : 0
             })
             .ToArrayAsync();
         
            return new MineFoodsQueryModel()
            {
                Day = queryModel.Day,
                Foods = AllMyneFoodsQueryModel,
                
            };

        }

    }

}
