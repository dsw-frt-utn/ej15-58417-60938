namespace Dsw2026Ej15.Api.Models
{
    public class DoctorModel
    {
        public record Request(
            string Name,
            string LicenseNumber,
            Guid SpecialtyId
        );

        public record Response(
            Guid Id,
            string Name,
            string LicenseNumber,
            string SpecialtyName
        );
    }
}