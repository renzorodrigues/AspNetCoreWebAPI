using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IAuthService
    {
        bool authenticate(Auth login);
        object register(Auth credentials);
    }
}