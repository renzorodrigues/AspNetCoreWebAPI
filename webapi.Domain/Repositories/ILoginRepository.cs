using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface ILoginRepository : IRepository<Login>
    {
         bool authenticate(Login login);
    }
}