using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class EvaluatorMap : IAutoMappingOverride< Evaluator>
    {
        public void Override(AutoMapping< Evaluator> mapping)
        {
            
        }
    }
}