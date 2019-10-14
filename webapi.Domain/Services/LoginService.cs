using webapi.Domain.Entities;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            this._loginRepository = loginRepository;
        }
        public bool authenticate(Login login)
        {
            var obj = this._loginRepository.authenticate(login);
            return obj;
        }
    }
}