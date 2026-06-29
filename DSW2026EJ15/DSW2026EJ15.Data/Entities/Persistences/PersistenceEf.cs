using DSW2026EJ15.Domain.Entities;
using DSW2026EJ15.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSW2025EJ15.Data.Entities.Persistences
{
    public class PersistenceEf : IPersistence
    {
        private AppDbContext _context;
        public PersistenceEf(AppDbContext appDbContext) {
            _context = appDbContext;
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.doctors.Add(doctor);   //añade un doctor a la tabla
            _context.SaveChanges();         //sube los cambios al context para luego actualizarlos en db
        }

        public bool DeactivateDoctor(Guid id)
        {
           Doctor d= _context.doctors.SingleOrDefault(s => s.Id == id);
            if (d != null)
            {
                d.IsActive = false;
                return true;
            }
            return false;
        }



        public Doctor? GetActiveDoctorById(Guid id)
        {
            Doctor d = _context.doctors.FirstOrDefault(s => s.Id == id); //devuelve solo un doctor qe cumple con la cond
            
            if(d!=null && d.IsActive)
            {
                return d;
            }

            return null;
        }
        

        public List<Doctor> GetActiveDoctors()
        {

            return _context.doctors.Where(d => d.IsActive == true).ToList(); //devuelve todos los doctores activos 
        }

        public Speciality? GetSpecialtyById(Guid id)
        {
            return _context.specialities.SingleOrDefault(s => s.Id == id);
        }
    }
}
