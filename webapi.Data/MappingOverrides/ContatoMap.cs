using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class ContatotMap : IAutoMappingOverride< Contato>
    {
        public void Override(AutoMapping<Contato> mapping)
        {
            
        }
    }
}