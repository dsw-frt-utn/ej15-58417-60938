using DSW2026EJ15.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSW2026EJ15.Data.Sources
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);
            modelBuilder.Entity<Speciality>().HasKey(s => s.Id);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialty);

            modelBuilder.Entity<Speciality>().HasData(
                new Speciality(
                    new Guid("11111111-1111-1111-1111-111111111111"),
                    "Cardiología",
                    "Especialidad médica del corazón"
                ),
                new Speciality(
                    new Guid("22222222-2222-2222-2222-222222222222"),
                    "Pediatría",
                    "Especialidad médica de niños"
                ),
                new Speciality(
                    new Guid("33333333-3333-3333-3333-333333333333"),
                    "Dermatología",
                    "Especialidad médica de la piel"
                )
            );
        }
    }
}