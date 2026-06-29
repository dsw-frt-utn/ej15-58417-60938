using DSW2026EJ15.Domain.Entities;
using DSW2026EJ15.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DSW2026EJ15.Data.Sources
{
    public class PersistenceEf : IPersistence
    {
        private readonly AppDbContext _context;

        public PersistenceEf(AppDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetActiveDoctors()
        {
            return _context.Doctors
                .Include(d => d.Specialty)
                .Where(d => d.IsActive)
                .ToList();
        }

        public Doctor? GetActiveDoctorById(Guid id)
        {
            return _context.Doctors
                .Include(d => d.Specialty)
                .SingleOrDefault(d => d.Id == id && d.IsActive);
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public bool DeactivateDoctor(Guid id)
        {
            Doctor? doctor = _context.Doctors
                .SingleOrDefault(d => d.Id == id && d.IsActive);

            if (doctor == null)
            {
                return false;
            }

            doctor.IsActive = false;
            _context.SaveChanges();

            return true;
        }

        public Speciality? GetSpecialtyById(Guid id)
        {
            return _context.Specialities
                .SingleOrDefault(s => s.Id == id);
        }
    }
}
