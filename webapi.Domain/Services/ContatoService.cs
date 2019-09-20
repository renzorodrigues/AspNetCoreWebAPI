using webapi.Domain.Entities;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IRepository<Contato> _repository;

        public ContatoService(IRepository<Contato> repository)
        {
            this._repository = repository;
        }
        public void insert(Contato contato)
        {
            this._repository.insert(contato);
        }
    }
}