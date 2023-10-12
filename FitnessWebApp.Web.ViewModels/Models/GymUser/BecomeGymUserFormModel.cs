namespace FitnessWebApp.Services.FormModels.GymUser
{
    using System.ComponentModel.DataAnnotations;

    using static FitnessWebApp.Common.EntityValidationConstants.GymUser;
    public class BecomeGymUserFormModel
    {
        [Required]
        [Range(MinHeight,MaxHeight)]
        public double Height { get; set; }
        [Required]
        [Range(MinWeight,MaxWeight)]
        public double Weight { get; set; }
        [Required]
        [Range(MinAge,MaxAge)]
        public int Age { get; set; }
    }
}
