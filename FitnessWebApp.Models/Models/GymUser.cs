namespace FitnessWebApp.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    using FitnessWebApp.Data.Models.Enums;
    using FitnessWebApp.Data.Models.Models;
    using FitnessWebApp.Models.Data;
    public class GymUser
    {
        public GymUser()
        {
            GymUserId = Guid.NewGuid();
            EatedFood = new HashSet<Food>();
        }
        [Key]
        public Guid GymUserId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Height { get; set; }
        [Required]
        public int Age { get; set; }
        public ICollection<Food> EatedFood { get; set; }
        public Sex? Sex { get; set; }
        public Activities? Activiti { get; set; }
    }
}
