using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface ILoginService
    {
        bool authenticate(Login login);
    }
}