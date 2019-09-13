using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IUserService
    {
         IEnumerable<User> getAll();
    }
}