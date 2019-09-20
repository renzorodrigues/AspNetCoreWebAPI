namespace webapi.Domain.Entities
{
    public class Avaliador : IEntity
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Function { get; set; }
    }
}