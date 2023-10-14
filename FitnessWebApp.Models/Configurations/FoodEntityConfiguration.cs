namespace FitnessWebApp.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using FitnessWebApp.Models.Models;
    public class FoodEntityConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(GenerateFoods());
        }

        private Food[] GenerateFoods()
        {
            ICollection<Food> foods = new HashSet<Food>();

            Food food;

            food = new Food()
            {
                FoodId = 1,
                Name = "Chicken breast",
                Protein = 31,
                Fat = 3.6,
                Carbs = 0
            };
            foods.Add(food);

            food = new Food()
            {
                FoodId = 2,
                Name = "Beef steak",
                Protein = 35,
                Fat = 10,
                Carbs = 0
            };
            foods.Add(food);



            return foods.ToArray();
        }
    }
}
