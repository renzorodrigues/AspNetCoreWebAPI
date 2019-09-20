using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> getAll();
        T getById(string id);
        void insert(T entity);
        void update(T entity);
        void delete(string id);
    }
}