using System.Collections.Generic;
using System.Linq;
using webapi.Data.Helpers;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Data.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        private readonly UnitOfWork _unitOfWork;
        public LoginRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public bool authenticate(Login login)
        {
            var result = this._unitOfWork.Session.Query<Login>()
            .Where(x => x.Email == login.Email && x.Password == login.Password);
            
            if (result.Any())
                return true;
            else
                return false;
        }
    }
}