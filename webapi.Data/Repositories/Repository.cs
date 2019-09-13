using System.Collections.Generic;
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
        public Repository(IUnitOfWork unitOfWork){
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IEnumerable<T> getAll()
        {
            return Session.Query<T>();
        }

        public T getById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void insert(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}