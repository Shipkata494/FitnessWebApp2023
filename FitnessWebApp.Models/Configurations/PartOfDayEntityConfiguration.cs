using FitnessWebApp.Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FitnessWebApp.Data.Models.Configurations
{
    public class PartOfDayEntityConfiguration : IEntityTypeConfiguration<PartOfDay>
    {

        public void Configure(EntityTypeBuilder<PartOfDay> builder)
        {
            builder.HasData(GeneratePartOfDays());
        }
        PartOfDay[] GeneratePartOfDays()
        {
            ICollection<PartOfDay> partOfDays = new HashSet<PartOfDay>();
            PartOfDay partOfDay;
            partOfDay = new PartOfDay()
            {
                Id = 1,
                Name = "Breakfast"
            };
            partOfDays.Add(partOfDay);

            partOfDay = new PartOfDay()
            {
                Id = 2,
                Name = "Lunch"
            };
            partOfDays.Add(partOfDay);

            partOfDay = new PartOfDay()
            {
                Id = 3,
                Name = "Diner"
            };
            partOfDays.Add(partOfDay);

            partOfDay = new PartOfDay()
            {
                Id = 4,
                Name = "Snack"
            };
            partOfDays.Add(partOfDay);
            return partOfDays.ToArray();
        }
    }

}
