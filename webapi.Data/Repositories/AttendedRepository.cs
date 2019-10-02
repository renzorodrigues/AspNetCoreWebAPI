using System.Collections.Generic;
using System.Linq;
using webapi.Data.Helpers;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Data.Repositories
{
    public class AttendedRepository : Repository<Attended>, IAttendedRepository
    {
        private readonly UnitOfWork _unitOfWork;
        public AttendedRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IEnumerable<Attended> getByName(string param)
        {
            var attendeds = this._unitOfWork.Session.Query<Attended>()
            .Where(x => x.Name.Contains(param) || x.RegistrationNumber.ToString() == param);
            return attendeds;
        }
    }
}