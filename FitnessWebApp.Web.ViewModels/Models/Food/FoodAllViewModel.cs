namespace FitnessWebApp.Web.ViewModels.Models.Food
{
    public class FoodAllViewModel
    {
        public string Name { get; set; } = null!;
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double TotalCalories => (Carbs * 4) + (Fat * 9) + (Protein * 4);
    }
}
