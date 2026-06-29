using DSW2026EJ15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSW2025EJ15.Data.Sources.DbConfig
{
    public class DoctorsEntityTypeConfig : IEntityTypeConfiguration<Doctor> 
    {

        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d=>d.Id).IsRequired();
            
        }
    }
 }

