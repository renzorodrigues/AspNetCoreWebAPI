using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class AvaliadorService : IAvaliadorService
    {
        private readonly IRepository<Avaliador> _repository;

        public AvaliadorService(IRepository<Avaliador> repository){
            this._repository = repository;
        }
        public IEnumerable<Avaliador> getAll()
        {
            return this._repository.getAll().ToList();
        }

        public Avaliador getById(string id)
        {
            return _repository.getById(id);
        }
    }
}