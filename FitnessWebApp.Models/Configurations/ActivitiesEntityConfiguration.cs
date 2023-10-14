using FitnessWebApp.Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWebApp.Data.Models.Configurations
{
    public class ActivitiesEntityConfiguration : IEntityTypeConfiguration<Activities>
    {
        public void Configure(EntityTypeBuilder<Activities> builder)
        {
            builder.HasData(GetActivities());
        }
        Activities[] GetActivities()
        {
            ICollection<Activities> activities = new HashSet<Activities>();
            Activities activiti = new Activities();
            activiti = new Activities()
            {
                Id = 1,
                Name = "Not Very Active",
            };
            activities.Add(activiti);
            activiti = new Activities()
            {
                Id = 2,
                Name = "Lightly Active",
            };
            activities.Add(activiti);

            activiti = new Activities()
            {
                Id = 3,
                Name = "Active",
            };
            activities.Add(activiti);

            activiti = new Activities()
            {
                Id = 4,
                Name = "Very Active",
            };
            activities.Add(activiti);

            return activities.ToArray();
        }

    }
}
