using System;
using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IAttendedService
    {
        IEnumerable<Attended> getAll();
        Attended getById(Guid id);
        void insert(Attended Attended);
        void update(Guid id, Attended Attended);
        void delete(Guid id);
    }
}