using System;

namespace webapi.Domain.Entities
{
    public class Login : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }
}