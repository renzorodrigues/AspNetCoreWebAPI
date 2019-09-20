using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Entities;
using webapi.Domain.Repositories;

namespace webapi.Domain.Services
{
    public class EvaluatorService : IEvaluatorService
    {
        private readonly IRepository<Evaluator> _repository;

        public EvaluatorService(IRepository<Evaluator> repository){
            this._repository = repository;
        }
        public IEnumerable<Evaluator> getAll()
        {
            return this._repository.getAll().ToList();
        }

        public Evaluator getById(Guid id)
        {
            return _repository.getById(id);
        }
    }
}