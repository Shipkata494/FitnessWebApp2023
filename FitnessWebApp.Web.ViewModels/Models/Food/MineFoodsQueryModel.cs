namespace FitnessWebApp.Web.ViewModels.Models.Food
{
    using System.ComponentModel.DataAnnotations;
   
    using FitnessWebApp.Web.ViewModels.Models.GymUser;
    public class MineFoodsQueryModel
    {
        public MineFoodsQueryModel()
        {
            Day = DateTime.UtcNow;
            Foods = new HashSet<MineFoodsViewModel>();
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        public IEnumerable<MineFoodsViewModel> Foods { get; set; }

       
    }
}
