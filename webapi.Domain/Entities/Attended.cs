﻿using System;
using webapi.Domain.Entities.Enum;

namespace webapi.Domain.Entities
{
    public class Attended : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int RegistrationNumber { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
