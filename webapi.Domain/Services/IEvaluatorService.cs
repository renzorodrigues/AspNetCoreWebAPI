using System;
using System.Collections.Generic;
using webapi.Domain.Entities;

namespace webapi.Domain.Services
{
    public interface IEvaluatorService
    {
         IEnumerable<Evaluator> getAll();
         Evaluator getById(Guid id);
    }
}