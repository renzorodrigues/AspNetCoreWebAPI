using System;

namespace webapi.Domain.Entities
{
    public class Contact : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string Email { get; set; }
    }
}