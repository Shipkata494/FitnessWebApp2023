namespace FitnessWebApp.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    using FitnessWebApp.Data.Models.Models;
    using static FitnessWebApp.Common.EntityValidationConstants.Food;

    public class Food
    {
        public Food()
        {
            GymUsersFoods = new HashSet<GymUsersFoods>();
        }
        [Key]
        public int FoodId { get; set; }
        [MaxLength(NameMaxLenght)]
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public double Carbs { get; set; }
        [Required]
        public double Protein { get; set; }
        [Required]
        public double Fat { get; set; }
        public double? Grams { get; set; }
        public ICollection<GymUsersFoods> GymUsersFoods { get; set; }
        public DateTime? EatingTime { get; set; }
        public int? PartOfDayId { get; set; }
        public PartOfDay? PartOfDay { get; set; }
        
    }
}
