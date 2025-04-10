using FootballClubIS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Context.Configuration
{
    class AchievementsFootballClubConfiguration : IEntityTypeConfiguration<AchievementsFootballClub>
    {
        public void Configure(EntityTypeBuilder<AchievementsFootballClub> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.PlayerId)
                .IsRequired(true);
        }
    }
}
