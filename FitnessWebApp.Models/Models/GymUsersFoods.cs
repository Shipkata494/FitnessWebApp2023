
namespace FitnessWebApp.Models.Models
{
    public class GymUsersFoods
    {
        public Guid GymUserId { get; set; }
        public GymUser GymUser { get; set; } = null!;
        public int FoodId { get; set; }
        public Food Food { get; set; } = null!;
    }
}
