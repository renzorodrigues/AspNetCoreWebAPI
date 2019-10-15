using System;

namespace webapi.Domain.Entities
{
    public class Auth : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        //public virtual byte[] HashPassword { get; set; }
        //public virtual byte[] SaltPassword { get; set; }
        public virtual Evaluator Evaluator { get; set; }
    }
}