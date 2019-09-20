using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class AtendidoService : IAtendidoService
    {
        private readonly IRepository<Atendido> _repository;
        private readonly IRepository<Contato> _repositoryContato;

        private readonly IUnitOfWork _unitOfWork;

        public AtendidoService(
            IRepository<Atendido> repository,
            IRepository<Contato> repositoryContato,
            IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._repositoryContato = repositoryContato;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Atendido> getAll()
        {
            return this._repository.getAll().ToList();
        }

        public Atendido getById(string id)
        {
            return this._repository.getById(id);
        }

        public void insert(Atendido atendido)
        {
            this._unitOfWork.BeginTransaction();
            atendido.Contato.Id = Guid.NewGuid().ToString();
            atendido.Id = Guid.NewGuid().ToString();
            this._repositoryContato.insert(atendido.Contato);
            this._repository.insert(atendido);
            this._unitOfWork.Commit();
        }

        public void update(string id, Atendido atendido)
        {
            Atendido entity = this._repository.getById(id);
            updateData(entity, atendido);
            this._repository.update(entity);
        }

        private void updateData(Atendido entity, Atendido user)
        {
            entity.Name = user.Name;
        }
    }
}