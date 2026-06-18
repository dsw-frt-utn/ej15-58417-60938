using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Domain.Interfaces
{
    public interface IPersistence
    {
        List<Doctor> GetActiveDoctors();

        Doctor? GetActiveDoctorById(Guid id);

        void AddDoctor(Doctor doctor);

        bool DeactivateDoctor(Guid id);

        Specialty? GetSpecialtyById(Guid id);
    }
}
