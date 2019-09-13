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

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }

        public T getById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void create(T entity)
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