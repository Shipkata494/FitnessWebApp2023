namespace FitnessWebApp.Services.FormModels.GymUser
{
    using FitnessWebApp.Data.Models.Enums;
    using FitnessWebApp.Data.Models.Models;
    using FitnessWebApp.Web.ViewModels.Models.Activities;
    using System.ComponentModel.DataAnnotations;

    using static FitnessWebApp.Common.EntityValidationConstants.GymUser;
    public class BecomeGymUserFormModel
    {
        public BecomeGymUserFormModel()
        {
            Activities = new HashSet<ActivitiesSelectionViewModel>();
        }
        [Required]
        [Range(MinHeight,MaxHeight)]
        public double Height { get; set; }
        [Required]
        [Range(MinWeight,MaxWeight)]
        public double Weight { get; set; }
        [Required]
        [Range(MinAge,MaxAge)]
        public int Age { get; set; }
        [Required]
        public Sex Sex { get; set; }
        public int ActivitiId { get; set; }
        [Required]
        public IEnumerable<ActivitiesSelectionViewModel> Activities { get; set; }
        // public Activities Activities { get; set; } = null!;
    }
}
