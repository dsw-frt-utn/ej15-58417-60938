using DSW2025EJ15.Data.Sources.DbConfig;
using DSW2026EJ15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSW2025EJ15.Data.Sources
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //llama al metodo en DoctorTypeConfig para aclararle propiedades de sus atributos
            //pasa como parametro el modelbuilderparticularizado para doctor
            new DoctorsEntityTypeConfig().Configure(modelBuilder.Entity<Doctor>());
            new SpecialityEntityTypeConfig().Configure(modelBuilder.Entity<Speciality>());

        }
    }
}
