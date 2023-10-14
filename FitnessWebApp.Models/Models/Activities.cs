namespace FitnessWebApp.Data.Models.Models
{
    using System.ComponentModel.DataAnnotations;

    using static FitnessWebApp.Common.EntityValidationConstants.Activities;
    public class Activities
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;
    }
}
