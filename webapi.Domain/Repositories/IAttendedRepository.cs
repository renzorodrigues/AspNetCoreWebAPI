using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;

namespace webapi.Domain.Repositories
{
    public interface IAttendedRepository : IRepository<Attended>
    {
        IEnumerable<Attended> getByName(string search);
    }
}