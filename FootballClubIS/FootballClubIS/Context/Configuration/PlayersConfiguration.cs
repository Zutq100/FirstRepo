using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballClubIS.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballClubIS.Context.Configuration
{
    class PlayersConfiguration : IEntityTypeConfiguration<Players>
    {
        public void Configure(EntityTypeBuilder<Players> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .HasMany(x => x.Achievements)
                .WithOne(x => x.Player)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.PlayerId)
                .IsRequired();
            builder
                .HasOne(x => x.Team)
                .WithOne(x => x.Player)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);
        }
    }
}
