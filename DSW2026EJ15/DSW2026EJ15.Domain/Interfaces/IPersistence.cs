using DSW2026EJ15.Domain.Entities;

namespace DSW2026EJ15.Domain.Interfaces 
{
    public interface IPersistence
    {
     
        List<Doctor> GetActiveDoctors();

        Doctor? GetActiveDoctorById(Guid id);

        void AddDoctor(Doctor doctor);

        bool DeactivateDoctor(Guid id);

        Speciality? GetSpecialtyById(Guid id);
    }
}
