using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> getAll();
        T getById(int id);
        void create(T entity);
        void update(T entity);
        void delete(int id);
    }
}