namespace FitnessWebApp.Services.Interfaces
{
    using FitnessWebApp.Services.FormModels.GymUser;
    using FitnessWebApp.Web.ViewModels.Models.Activities;
    using FitnessWebApp.Web.ViewModels.Models.Food;

    public interface IGymUserService
    {
        Task<bool> GymUserExistsByUserIdAsync(string? UserId);
        Task AddGymUserAsync(string userId,BecomeGymUserFormModel model);
        Task<string> GetUserIdAndReturnGymUserIdAsync(string userId);
        Task AddFoodInFoodsCollectionAsync(string userId, DiaryUserFormModel model);
        Task<MineFoodsQueryModel> MineFoodsAsync(MineFoodsQueryModel queryModel,string userId);
        Task<IEnumerable<ActivitiesSelectionViewModel>> AllActivitiesAsync();
    }
}
