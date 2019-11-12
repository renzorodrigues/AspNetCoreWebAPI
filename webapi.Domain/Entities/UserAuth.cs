using System;

namespace webapi.Domain.Entities
{
    public class UserAuth : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
<<<<<<< HEAD:webapi.Domain/Entities/Auth.cs
        public virtual string HashPassword { get; set; }   
        public virtual string SaltPassword { get; set; }
        public virtual Evaluator Evaluator { get; set; }
=======
        public virtual string HashPassword { get; set; }
        public virtual string SaltPassword { get; set; }
>>>>>>> 0632d3c67d5db9c903a7aff94ccf899486cff333:webapi.Domain/Entities/UserAuth.cs
    }
}