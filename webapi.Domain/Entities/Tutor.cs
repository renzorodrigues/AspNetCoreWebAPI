using System;
using webapi.Domain.Entities.Enum;

namespace webapi.Domain.Entities
{
    public class Tutor : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual TutorType TutorType { get; set; }
    }
}