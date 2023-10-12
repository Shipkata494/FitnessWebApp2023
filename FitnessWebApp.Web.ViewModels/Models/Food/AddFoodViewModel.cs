namespace FitnessWebApp.Web.ViewModels.Models.Food
{
    using System.ComponentModel.DataAnnotations;
    using static FitnessWebApp.Common.EntityValidationConstants.Food;
    public class AddFoodViewModel
    {
        [Required]
        [StringLength(NameMaxLenght, MinimumLength = NameMinLenght)]
        public string Name { get; set; } = null!;
        [Required]
        [Range(MinMacrosValue,MaxMacrosValue)]
        public double Protein { get; set; }
        [Required]
        [Range(MinMacrosValue, MaxMacrosValue)]
        public double Fat { get; set; }
        [Required]
        [Range(MinMacrosValue, MaxMacrosValue)]
        public double Carbs { get; set; }
    }
}
