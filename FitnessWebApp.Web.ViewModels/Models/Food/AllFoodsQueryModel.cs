namespace FitnessWebApp.Web.ViewModels.Models.Food
{
    using System.ComponentModel.DataAnnotations;

    using FitnessWebApp.Web.ViewModels.Enums;
    using FitnessWebApp.Web.ViewModels.Models.GymUser;

    using static FitnessWebApp.Common.GeneralApplicationConstants;
    public class AllFoodsQueryModel
    {
        public AllFoodsQueryModel()
        {
            CurrentPage = DefaultPage;
            FoodsPerPage = DefaultFoodsPerPage;

            Foods = new HashSet<MineFoodsViewModel>();
        }


        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Foods By")]
         public FoodSorting FoodSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Foods On Page")]
        public int FoodsPerPage { get; set; }
        public int TotalFoods { get; set; }


        public IEnumerable<MineFoodsViewModel> Foods { get; set; }
    }
}
