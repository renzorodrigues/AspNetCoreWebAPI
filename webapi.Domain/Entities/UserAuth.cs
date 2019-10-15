using System;

namespace webapi.Domain.Entities
{
    public class UserAuth : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string HashPassword { get; set; }
        public virtual string SaltPassword { get; set; }
        public virtual Evaluator Evaluator { get; set; }
    }
}