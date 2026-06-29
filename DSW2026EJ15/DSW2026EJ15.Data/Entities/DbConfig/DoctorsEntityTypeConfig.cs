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
            
            builder.HasOne(d => d.Specialty).WithMany().HasForeignKey(d =>d.Specialty.Id);

            //un doctor tiene una especialidad HasOne
            //With many va vacio porque es una relacion unidireccional
            //HasForeignkey le indica cual es la clave pricipal de especialidad 
            //esto es lo unico que configuro porque lo demas lo configura entityframework por defecto
        }


    }
    }
 }

