using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IAttendedService
    {
        IEnumerable<Attended> getAll();
        Attended getById(Guid id);
        object insert(Attended Attended);
        void update(Guid id, Attended Attended);
        void delete(Guid id);
        IEnumerable<Attended> getByName(string search);
    }
}