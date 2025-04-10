using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballClubIS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballClubIS.Context.Configuration
{
    class FootballTeamConfiguration : IEntityTypeConfiguration<FootballTeam>
    {
        public void Configure(EntityTypeBuilder<FootballTeam> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.Team)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey("TypeId")
                .IsRequired();
        }
    }
}
