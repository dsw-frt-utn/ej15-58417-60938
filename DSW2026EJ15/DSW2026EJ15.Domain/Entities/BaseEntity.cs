using System;

namespace DSW2026EJ15.Domain.Entities
{
    public abstract class BaseEntity
    {
        private Guid _id;

        public BaseEntity()
        {
            _id = Guid.NewGuid();
        }

        public BaseEntity(Guid id)
        {
            _id = id;
        }

        public Guid Id
        {
            get { 
                return _id; 
            }
            set { 
                _id = value; 
            }
        }
    }
}