using System;

namespace DevCA.Business.Model
{
    public abstract class Entity
    {
        public long Id { get; set; }

        public DateTime DateRegistration { get; set; }
    }
}