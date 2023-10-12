namespace FitnessWebApp.Web.ViewModels.Models.Food
{
    using System.ComponentModel.DataAnnotations;

    public class FilterEatedFoodFormModel
    {
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
