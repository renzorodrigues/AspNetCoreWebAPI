using System;
using webapi.Domain.Entities;

namespace webapi.Domain.Helpers
{
    public class CreateGUID : ICreateGUID
    {
        public void newGuid(Guid id)
        {
            id = Guid.NewGuid();
        }
    }
}