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
            return _repository.getAll().ToList();
        }
    }
}