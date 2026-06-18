using Dsw2026Eje15.Api.Models;

using Microsoft.AspNetCore.Mvc;

namespace Dsw2026Eje15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")] //establece uri del controlador
    public class DoctorsController : ControllerBase
    {
        private readonly IPersistence _persistence; 
        
        public DoctorsController( IPersitence persistence)
        {
            _persistence = persistence;
        }

        [HttpPost] //indica que la funcion de abajo es Post
        public async Task<IActionResult> CreateDoctors(DoctorModel.request doctor)
        {
            //IActionResult es la interfaz estandar
            //cuando queremos retornar mensajes de estados y asi transformarlos en codigos de estado

            if( (string.IsNullOrWhiteSpace(doctor.name) || 
                string.IsNullOrWhiteSpace(doctor.LicenseNumber))
            {
                return BadRequest();  //devuelve error
            }

            var speciality = _persistence.GetSpecialityById(doctor.SpecialityId); //verifica que el numero de especialidad este dentro del json
            return Created();  //devuelve el codigo de estado 201
        }
        // cuando devolvemos un Ok, segun la interfaz ActionResult, se transforma en un 200
        // el body indica las cosas que pide el request,seria lo que esta definidio en doctors model
        
        
         
        
        
        
        
        
        //cada endpoint se corresponde a un metodo
    }
}
