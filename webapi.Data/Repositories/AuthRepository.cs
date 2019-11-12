using System.Linq;
using webapi.Data.Helpers;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Data.Repositories
{
    public class AuthRepository : Repository<UserAuth>, IUserAuthRepository
    {
        private readonly UnitOfWork _unitOfWork;
        public AuthRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public UserAuth authenticate(UserAuth credentials)
        {
            var result = this._unitOfWork.Session.Query<UserAuth>()
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