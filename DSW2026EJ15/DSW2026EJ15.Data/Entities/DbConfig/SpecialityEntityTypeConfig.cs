using DSW2026EJ15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSW2025EJ15.Data.Entities.DbConfig
{
    public class SpecialityEntityTypeConfig : IEntityTypeConfiguration<Speciality>
    {

        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            //crea la tabla de speciality en la bd unicamente
            // no cre
        }
    }
}
