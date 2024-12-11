using FaculityInform.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaculityInform.EFCore.Context.Configuration
{
    class DepartamentsConfiguration : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder
                .HasKey(e => e.Id);
            builder
                .ToTable(nameof(Departments));
            builder
                .HasMany(x => x.Directions)
                .WithOne(x => x.Department)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
            builder
                .HasMany(x => x.CompositionOfTeachers)
                .WithOne(x => x.Department)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
