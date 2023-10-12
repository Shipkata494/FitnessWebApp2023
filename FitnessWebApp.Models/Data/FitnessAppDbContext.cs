namespace FitnessWebApp.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using FitnessWebApp.Data.Models.Models;
    using FitnessWebApp.Models.Data;
    using FitnessWebApp.Models.Models;
    public class FitnessAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options)
            : base(options)
        {

        }
        public DbSet<GymUser> GymUsers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<GymUsersFoods> GymUsersFoods { get; set; }
        public DbSet<PartOfDay> PartOfDay { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GymUsersFoods>()
                .HasKey(gf => new
                {
                    gf.FoodId,
                    gf.GymUserId
                });
            builder.Entity<Food>()
                .HasData(new Food { FoodId = 1, Name = "Chicken breast", Protein = 31, Fat = 3.6, Carbs = 0 },
                         new Food { FoodId = 2, Name = "Beef steak", Protein = 35, Fat = 10, Carbs = 0 });
            builder.Entity<PartOfDay>()
                .HasData(new PartOfDay { Id = 1, Name = "Breakfast" },
                         new PartOfDay { Id = 2, Name = "Lunch" },
                         new PartOfDay { Id = 3, Name = "Diner" },
                         new PartOfDay { Id = 4, Name = "Snack" });
                
            base.OnModelCreating(builder);
        }
    }
}