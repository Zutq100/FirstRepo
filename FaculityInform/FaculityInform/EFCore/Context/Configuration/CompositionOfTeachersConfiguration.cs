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
    class CompositionOfTeachersConfiguration : IEntityTypeConfiguration<CompositionOfTeachers>
    {
        public void Configure(EntityTypeBuilder<CompositionOfTeachers> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .ToTable(nameof(CompositionOfTeachers));
        }
    }
}
