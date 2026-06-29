using DSW2025EJ15.Data.Entities.DbConfig;
using DSW2026EJ15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSW2025EJ15.Data.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> doctors { get; set; } //tabladoctores
        public DbSet<Speciality> specialities { get; set; } //tabla especialidad 

        //cuando se inicializa por primera vez la app, EF llama a esta funcion para setear propiedades en los atributos de las tablas  
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //llama al metodo en DoctorTypeConfig para aclararle propiedades de sus atributos
            //pasa como parametro el modelbuilderparticularizado para doctor
            new DoctorsEntityTypeConfig().Configure(modelBuilder.Entity<Doctor>());
            new SpecialityEntityTypeConfig().Configure(modelBuilder.Entity<Speciality>());

        }
    }
}
