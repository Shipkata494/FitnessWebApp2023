namespace FitnessWebApp.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using FitnessWebApp.Data.Models.Models;
    using FitnessWebApp.Models.Data;
    using FitnessWebApp.Models.Models;
    using FitnessWebApp.Data.Models.Configurations;
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
        public DbSet<Activities> Activities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GymUsersFoods>()
                .HasKey(gf => new
                {
                    gf.FoodId,
                    gf.GymUserId
                });
            builder.ApplyConfiguration(new FoodEntityConfiguration());
            builder.ApplyConfiguration(new PartOfDayEntityConfiguration());
            builder.ApplyConfiguration(new ActivitiesEntityConfiguration());

            base.OnModelCreating(builder);
        }
    }
}