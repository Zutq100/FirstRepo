using FootballClubIS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubIS.Context.Configuration
{
    class TypeTeamConfiguration : IEntityTypeConfiguration<TypeTeam>
    {
        public void Configure(EntityTypeBuilder<TypeTeam> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
