namespace webapi.Domain.Entities
{
    public class Contato : IEntity
    {
        public virtual string Id { get; set; }
        public virtual string TelphoneNumber { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string Email { get; set; }
    }
}