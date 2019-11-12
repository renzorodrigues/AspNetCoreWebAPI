using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IAuthRepository : IRepository<UserAuth>
    {
         UserAuth authenticate(UserAuth credentials);
    }
}