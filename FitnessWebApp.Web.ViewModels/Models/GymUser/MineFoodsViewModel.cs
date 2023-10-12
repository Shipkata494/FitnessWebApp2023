namespace FitnessWebApp.Web.ViewModels.Models.GymUser
{
    public class MineFoodsViewModel
    {
        public string Name { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Grams { get; set; }
        public DateTime DateTime { get; set; }
        public double TotalCalories => (((Carbs * 4) + (Fat * 9) + (Protein * 4)) /100) * Grams;

    }
}
