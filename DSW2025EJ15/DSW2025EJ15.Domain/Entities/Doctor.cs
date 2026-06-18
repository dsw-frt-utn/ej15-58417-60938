using System;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        private string _name;
        private string _licenseNumber;
        private bool _isActive;
        private Specialty _specialty;

        public Doctor()
        {
            _name = string.Empty;
            _licenseNumber = string.Empty;
            _isActive = true;
            _specialty = new Specialty();
        }

        public Doctor(string name, string licenseNumber, bool isActive, Specialty specialty)
        {
            _name = name;
            _licenseNumber = licenseNumber;
            _isActive = isActive;
            _specialty = specialty;
        }

        public Doctor(Guid id, string name, string licenseNumber, bool isActive, Specialty specialty) : base(id)
        {
            _name = name;
            _licenseNumber = licenseNumber;
            _isActive = isActive;
            _specialty = specialty;
        }

        public string Name
        {
            get { 
                return _name; 
            }
            set { 
                _name = value; 
            }
        }

        public string LicenseNumber
        {
            get {
                return _licenseNumber; 
            }
            set { 
                _licenseNumber = value; 
            }
        }

        public bool IsActive
        {
            get { 
                return _isActive; 
            }
            set { 
                _isActive = value; 
            }
        }

        public Specialty Specialty
        {
            get { 
                return _specialty; 
            }
            set { 
                _specialty = value; 
            }
        }
    }
}