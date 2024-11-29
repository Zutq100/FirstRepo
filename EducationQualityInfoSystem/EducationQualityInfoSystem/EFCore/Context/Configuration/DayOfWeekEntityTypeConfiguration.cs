using EducationQualityInfoSystem.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Context.Configuration
{
    internal class DayOfWeekEntityTypeConfiguration : IEntityTypeConfiguration<DayOfWeekModel>
    {
        public void Configure(EntityTypeBuilder<DayOfWeekModel> builder)
        {
            builder
                .HasKey(x => x.ID);
            builder
                .ToTable("DayOfWeek");
        }
    }
}
