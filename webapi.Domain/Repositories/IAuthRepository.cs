using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IAuthRepository : IRepository<Auth>
    {
         bool authenticate(Auth credentials);
    }
}