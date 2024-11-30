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
    internal class StudentEntityTypeConfiguration : IEntityTypeConfiguration<StudentsModel>
    {
        public void Configure(EntityTypeBuilder<StudentsModel> builder)
        {
            builder
                .HasKey(x => x.ID);
            builder
                .ToTable("Students");
            builder
                .HasMany(x => x.MainModel)
                .WithOne(x => x.Students)
                .HasForeignKey(x => x.StudentsID)
                .IsRequired(false);
        }
    }
}
