using System;

namespace webapi.Domain.Entities
{
    public class Evaluator : IEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Function { get; set; }
    }
}