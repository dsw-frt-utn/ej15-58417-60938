using System;
using System.Collections.Generic;
using System.IO;


public class PersistenceMemory
{
    private List<Speciality> _specialities;
    private List<Doctors> _doctors;


    Public PersistenceMemory() {
        LoadSpecialities();
    }
    
    public LoadSpecialities()
    {
        try {
            
        
        var pathJson = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sources", "specialities.json");
        var strJson = File.ReadAllText(pathJson);
        var specialitie= JsonSerializer.Des

        }

        catch ()
        {

        }
    }



    public Speciality? GetSpecialityById(Guid? id)
    {
        return _specialities.SingleOrDefault(e=>e.id)
    }
}
