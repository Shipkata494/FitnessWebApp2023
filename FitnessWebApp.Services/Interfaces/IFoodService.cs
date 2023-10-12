namespace FitnessWebApp.Services.Interfaces
{
    using FitnessWebApp.Web.ViewModels.Models.Food;
    public interface IFoodService
    {

        Task<AllFoodsAndFiltredViewModel> AllAsync(AllFoodsQueryModel queryModel);
        Task AddAsync(AddFoodViewModel model);
        Task<int> GetFoodIdByFoodNameAsync(string name);
    }
}
