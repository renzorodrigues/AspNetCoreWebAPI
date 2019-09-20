using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using webapi.Data.Helpers;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private UnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IEnumerable<T> getAll()
        {
            return this.Session.Query<T>();
        }

        public T getById(Guid id)
        {
            return this.Session.Get<T>(id);
        }

        public void insert(T entity)
        {
            this.Session.Save(entity);
        }

        public void update(T entity)
        {
            this.Session.Update(entity);
        }

        public void delete(T entity)
        {
            this.Session.Delete(entity);
        }
    }
}