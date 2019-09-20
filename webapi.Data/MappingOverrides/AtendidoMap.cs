using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class AtendidoMap : IAutoMappingOverride<Atendido>
    {
        public void Override(AutoMapping<Atendido> mapping)
        {
            mapping.References(x => x.Contato).Not.LazyLoad();
        }
    }
}