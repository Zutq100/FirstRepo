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
    internal class DisciplineEntityTypeConfiguration : IEntityTypeConfiguration<DisciplinesModel>
    {
        public void Configure(EntityTypeBuilder<DisciplinesModel> builder)
        {
            builder
                .HasKey(x => x.ID);
            builder
                .ToTable("Disciplines");
        }
    }
}
