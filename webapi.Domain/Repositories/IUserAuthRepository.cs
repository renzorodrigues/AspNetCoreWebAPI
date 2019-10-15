using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IUserAuthRepository : IRepository<UserAuth>
    {
         bool authenticate(UserAuth credentials);
    }
}