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

        public T getById(string id)
        {
            return this.Session.Get<T>(id);
        }

        public void insert(T entity)
        {
            this.Session.Save(entity);
        }

        public void update(T entity)
        {
            this._unitOfWork.BeginTransaction();
            this.Session.Update(entity);
            this._unitOfWork.Commit();
        }

        public void delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}