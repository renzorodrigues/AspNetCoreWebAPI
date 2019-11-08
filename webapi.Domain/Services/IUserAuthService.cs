using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IUserAuthService
    {
        string authenticate(UserAuth login);
        UserAuth register(UserAuth credentials);
    }
}