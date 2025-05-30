﻿using EducationQualityInfoSystem.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationQualityInfoSystem.EFCore.Context.Configuration
{
    internal class MainEntityTypeConfiguration : IEntityTypeConfiguration<MainModel>
    {
        public void Configure(EntityTypeBuilder<MainModel> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .ToTable("MainTable");
            builder
                .Property(x => x.EducationQuality)
                .IsRequired()
                .HasDefaultValue(0);
            
        }
    }
}
