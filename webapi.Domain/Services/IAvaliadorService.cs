using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IAvaliadorService
    {
         IEnumerable<Avaliador> getAll();
         Avaliador getById(string id);
    }
}