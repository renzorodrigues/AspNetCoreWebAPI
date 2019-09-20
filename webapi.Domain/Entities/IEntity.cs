using System;

namespace webapi.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}