using System;
using webapi.Domain.Entities;

namespace webapi.Domain.Helpers
{
    public interface ICreateGUID
    {
         void newGuid(Guid id);
    }
}