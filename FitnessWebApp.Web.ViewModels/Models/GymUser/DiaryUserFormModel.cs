namespace FitnessWebApp.Services.FormModels.GymUser
{
    using System.ComponentModel.DataAnnotations;
    public class DiaryUserFormModel
    {
        public DiaryUserFormModel()
        {
            Date = DateTime.UtcNow;
            PartOfDays = new HashSet<FoodSelectPartOfDayFormModel>();
        }
        [Required]
        [Display(Name = "Food")]
        public string Name { get; set; } 
        [Required]
        public IEnumerable<FoodSelectPartOfDayFormModel> PartOfDays { get; set; } 
        [Required]
        [Display(Name = "Part")]
        public int PartId { get; set; }
        [Required]
        public double Grams { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 
    }
}
