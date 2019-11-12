using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IUserAuthService
    {
        bool authenticate(UserAuth login);
        object register(UserAuth credentials);
    }
}