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
    class DirectionsConfiguration : IEntityTypeConfiguration<Directions>
    {
        public void Configure(EntityTypeBuilder<Directions> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .ToTable(nameof(Directions));
            builder
                .HasMany(x => x.Groups)
                .WithOne(x => x.Directions)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
