using System;
using System.Resources;
using Dsw2026Eje15.Data;
using WebAll.Components;

public class PersistenceMemory : IPersistence
{
    private var _specialities = ResourceReader("specialities.json");
    
    public Speciality? GetSpecialityById(Guid? id)
    {
        return _specialities.SingleOrDefault(e=>e.id)
    }
}
