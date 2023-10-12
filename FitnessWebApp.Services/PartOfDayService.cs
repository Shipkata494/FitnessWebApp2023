namespace FitnessWebApp.Services
{
    using Microsoft.EntityFrameworkCore;

    using FitnessWebApp.Services.FormModels.GymUser;
    using FitnessWebApp.Services.Interfaces;
    using FitnessWebApp.Web.Data;
    public class PartOfDayService : IPartOfDayService
    {
        private readonly FitnessAppDbContext dbContext;

        public PartOfDayService(FitnessAppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<IEnumerable<FoodSelectPartOfDayFormModel>> AllPartOfDaysAsync()
        {
            IEnumerable<FoodSelectPartOfDayFormModel> allParts = await dbContext
                .PartOfDay
                .AsNoTracking()
                .Select(c => new FoodSelectPartOfDayFormModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return allParts;
        }


        public async Task<FoodSelectPartOfDayFormModel> PartOfDaysAsync(int partId)
        {

            return await dbContext.PartOfDay.Select(p => new FoodSelectPartOfDayFormModel()
            {
                Id = p.Id,
                Name = p.Name,
            }).FirstAsync(p => p.Id == partId);
        }
    }
}
