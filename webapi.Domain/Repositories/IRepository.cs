using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> getAll();
        T getById(Guid id);
        object insert(T entity);
        void update(T entity);
        void delete(T entity);
    }
}