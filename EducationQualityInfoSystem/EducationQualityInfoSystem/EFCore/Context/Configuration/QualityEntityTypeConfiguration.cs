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
    internal class QualityEntityTypeConfiguration : IEntityTypeConfiguration<QualityModel>
    {
        public void Configure(EntityTypeBuilder<QualityModel> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .ToTable("Quality");
            builder
                .HasOne(x => x.Student)
                .WithMany(x => x.Quality)
                .HasForeignKey(x => x.StudentID)
                .IsRequired(false);
            builder
                .HasOne(x => x.DayOfWeek)
                .WithMany(x => x.Quality)
                .HasForeignKey(x => x.DayOfWeekID)
                .IsRequired(false);
            builder
                .HasOne(x => x.Disciplines)
                .WithMany(x => x.Quality)
                .HasForeignKey(x => x.DisciplineID)
                .IsRequired(false);
            builder
                .Property(x => x.IsPresent)
                .HasDefaultValue(false);
            builder
                .Property(x => x.IsEvaluated)
                .HasDefaultValue(false);
        }
    }
}
