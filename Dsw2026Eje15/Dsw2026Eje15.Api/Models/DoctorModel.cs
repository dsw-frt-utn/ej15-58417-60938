namespace Dsw2026Eje15.Api.Models;

public record DoctorModel()
{
    public record request(string name, string LicenseNumber, Guid SpecialityId); //estructura request
    // es por convencion, ya que se utiliza para devolver datos con una estructura y otra para pedir datos 
}