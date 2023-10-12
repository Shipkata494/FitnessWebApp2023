namespace FitnessWebApp.Services.FormModels.GymUser
{
    public class AddFoodInFoodsCollectionFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
    }
}
