using FitnessWebApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWebApp.Web.ViewModels.Models.GymUser
{
    public class GymUserCaloriesCalculateServiceModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public int ActivitiId { get; set; }
    }
}
