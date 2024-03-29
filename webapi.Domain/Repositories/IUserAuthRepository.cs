using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IUserAuthRepository : IRepository<UserAuth>
    {
         UserAuth authenticate(UserAuth credentials);
    }
}