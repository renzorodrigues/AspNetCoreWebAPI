using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class AvaliadorMap : IAutoMappingOverride< Avaliador>
    {
        public void Override(AutoMapping< Avaliador> mapping)
        {
            
        }
    }
}