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

        public Auth authenticate(Auth credentials)
        {
            var result = this._unitOfWork.Session.Query<Auth>()
            .Where(x => x.Email == credentials.Email);
            
            if (result.Any())
            {
                return result.FirstOrDefault();
            } 
            else
                return null;
        }
    }
}