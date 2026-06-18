using DSW2025EJ15.Api.Models;
using DSW2025EJ15.Domain.Entities;
using DSW2025EJ15.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DSW2025EJ15.Domain.Exceptions; 

namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IPersistence _persistence;

        public DoctorsController(IPersistence persistence)
        {
            _persistence = persistence;
        }

        [HttpPost]
        public IActionResult CreateDoctor([FromBody] DoctorModel.Request doctor)
        {
            if (string.IsNullOrWhiteSpace(doctor.Name))
            {
                throw new ValidationException("Name es requerido.");
            }

            if (string.IsNullOrWhiteSpace(doctor.LicenseNumber))
            {
                throw new ValidationException("LicenseNumber es requerido.");
            }

            Speciality? speciality = _persistence.GetSpecialtyById(doctor.SpecialtyId);

            if (speciality == null) 
            {
                throw new ValidationException("SpecialtyId debe existir.");
            }

            Doctor newDoctor = new Doctor(
                doctor.Name,
                doctor.LicenseNumber,
                true,
                speciality
            );

            _persistence.AddDoctor(newDoctor);

            DoctorModel.Response response = new DoctorModel.Response(
                newDoctor.Id,
                newDoctor.Name,
                newDoctor.LicenseNumber,
                newDoctor.Specialty.Name
            );

            return CreatedAtAction(
                nameof(GetDoctorById),
                new { id = newDoctor.Id },
                response
            );
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            List<DoctorModel.Response> doctors = _persistence
                .GetActiveDoctors()
                .Select(doctor => new DoctorModel.Response(
                    doctor.Id,
                    doctor.Name,
                    doctor.LicenseNumber,
                    doctor.Specialty.Name
                ))
                .ToList();

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(Guid id)
        {
            Doctor? doctor = _persistence.GetActiveDoctorById(id);

            if (doctor == null)
            {
                return NotFound("No se encontró el médico o no está activo.");
            }

            DoctorModel.Response response = new DoctorModel.Response(
                doctor.Id,
                doctor.Name,
                doctor.LicenseNumber,
                doctor.Specialty.Name
            );

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(Guid id)
        {
            Doctor? doctor = _persistence.GetActiveDoctorById(id);

            if (doctor == null)
            {
                return NotFound("No se encontró el médico o no está activo.");
            }

            _persistence.DeactivateDoctor(id);

            return NoContent();
        }
    }
}