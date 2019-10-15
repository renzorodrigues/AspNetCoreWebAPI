using System.Linq;
using webapi.Data.Helpers;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Data.Repositories
{
    public class UserAuthRepository : Repository<UserAuth>, IUserAuthRepository
    {
        private readonly UnitOfWork _unitOfWork;
        public UserAuthRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public bool authenticate(UserAuth credentials)
        {
            var result = this._unitOfWork.Session.Query<UserAuth>()
            .Where(x => x.Email == credentials.Email && x.Password == credentials.Password);
            
            if (result.Any())
                return true;
            else
                return false;
        }
    }
}