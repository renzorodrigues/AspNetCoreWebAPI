using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository){
            this._repository = repository;
        }
        public IEnumerable<User> getAll()
        {
            return this._repository.getAll().ToList();
        }

        public User getById(int id)
        {
            return this._repository.getById(id);
        }

        public void insert(User user)
        {
            this._repository.insert(user);
        }

        public void update(int id, User user)
        {
            User entity = this._repository.getById(id);
            updateData(entity, user);
            this._repository.update(entity);
        }

        private void updateData(User entity, User user)
        {
            entity.Name = user.Name;
        }
    }
}