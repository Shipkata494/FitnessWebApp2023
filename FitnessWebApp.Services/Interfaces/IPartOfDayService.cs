namespace FitnessWebApp.Services.Interfaces
{
    using FitnessWebApp.Services.FormModels.GymUser;
    public interface IPartOfDayService
    {
        Task<IEnumerable<FoodSelectPartOfDayFormModel>> AllPartOfDaysAsync();
        Task<FoodSelectPartOfDayFormModel> PartOfDaysAsync(int partId);
    }
}
