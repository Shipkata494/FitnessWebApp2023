namespace FitnessWebApp.Web.ViewModels.Models.Food
{
    using FitnessWebApp.Web.ViewModels.Models.GymUser;

    public class AllFoodsAndFiltredViewModel
    {
       
            public AllFoodsAndFiltredViewModel()
            {
                Foods = new HashSet<MineFoodsViewModel>();
            }

            public int TotalFoodCount { get; set; }

            public IEnumerable<MineFoodsViewModel> Foods { get; set; }
        
    }
}
