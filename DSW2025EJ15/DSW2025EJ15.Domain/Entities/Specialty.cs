using System;

namespace Dsw2026Ej15.Domain.Entities
{
    public class Specialty : BaseEntity
    {
        private string _name;
        private string _description;

        public Specialty()
        {
            _name = string.Empty;
            _description = string.Empty;
        }

        public Specialty(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public Specialty(Guid id, string name, string description) : base(id)
        {
            _name = name;
            _description = description;
        }

        public string Name
        {
            get { 
                return _name; 
            }
            set { 
                _name = value; }
        }

        public string Description
        {
            get { 
                return _description; 
            }
            set { 
                _description = value; 
            }
        }
    }
}