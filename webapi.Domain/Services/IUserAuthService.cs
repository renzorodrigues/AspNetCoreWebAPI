using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IAuthService
    {
        bool authenticate(UserAuth login);
        object register(UserAuth credentials);
    }
}