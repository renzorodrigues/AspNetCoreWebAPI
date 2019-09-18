using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<User> getAll();
        User getById(int id);
        void insert(User user);
        void update(int id, User user);
    }
}