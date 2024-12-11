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
    class StudentsConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .ToTable(nameof(Students));
            builder
                .HasOne(x => x.Group)
                .WithMany(x => x.Students)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
