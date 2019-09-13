using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;

        public UserService(IRepository<User> userRepo){
            this._userRepo = userRepo;
        }
        public IEnumerable<User> getAll()
        {
            return _userRepo.getAll().ToList();
        }
    }
}