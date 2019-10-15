using System.Linq;
using webapi.Data.Helpers;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Data.Repositories
{
    public class AuthRepository : Repository<Auth>, IAuthRepository
    {
        private readonly UnitOfWork _unitOfWork;
        public AuthRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public bool authenticate(Auth credentials)
        {
            var result = this._unitOfWork.Session.Query<Auth>()
            .Where(x => x.Email == credentials.Email && x.Password == credentials.Password);
            
            if (result.Any())
                return true;
            else
                return false;
        }
    }
}