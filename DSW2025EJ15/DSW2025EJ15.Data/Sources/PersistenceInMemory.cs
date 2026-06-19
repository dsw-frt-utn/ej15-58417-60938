using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DSW2025EJ15.Domain.Entities;
using DSW2025EJ15.Data.Dtos;
using DSW2025EJ15.Domain.Entities;
using DSW2025EJ15.Domain.Interfaces;

namespace DSW2025EJ15.Data.Sources;
public class PersistenceInMemory :IPersistence 
{
    private List<Speciality> _specialities = [];
    private List<Doctor> _doctors = []; 


    public PersistenceInMemory() {
        LoadSpecialities();
    }

    public void AddDoctor(Doctor doctor)
    {
        
    }

    public bool DeactivateDoctor(Guid id)
    {
        return false;
    }

    public Doctor? GetActiveDoctorById(Guid id)
    {
        
        return _doctors.SingleOrDefault(s => s.Id == id);
    }

    public List<Doctor> GetActiveDoctors()
    {
        return _doctors;
    }

    public Speciality? GetSpecialtyById(Guid id)
    {
        return _specialities.SingleOrDefault(s => s.Id == id);
    }

    public void LoadSpecialities()
    {
        try {
            
        
        var pathJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
        var strJson = File.ReadAllText(pathJson);
        var specialities = JsonSerializer.Deserialize<List<SpecialityDTO>>(strJson, //deserializa json 
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? [];   //problemas con cammel case en atributos del json

        _specialities = [.. specialities.Select(s => new Speciality(s.Id, s.Name, s.Description))]; //crea entidades y las almacena en _speciality mendiante linq


        }

        catch (Exception e)
        {
            Console.WriteLine("Error al cargar");
        }
    }


   
}
