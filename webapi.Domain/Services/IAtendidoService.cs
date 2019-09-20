using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IAtendidoService
    {
        IEnumerable<Atendido> getAll();
        Atendido getById(string id);
        void insert(Atendido atendido);
        void update(string id, Atendido atendido);
    }
}