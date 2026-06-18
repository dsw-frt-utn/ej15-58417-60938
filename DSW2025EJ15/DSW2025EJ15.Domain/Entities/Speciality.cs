using System;

namespace DSW2025EJ15.Domain.Entities
{
    public class Speciality : BaseEntity
    {
        private string _name;
        private string _description;

        public Speciality()
        {
            _name = string.Empty;
            _description = string.Empty;
        }

        public Speciality(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public Speciality(Guid id, string name, string description) : base(id)
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