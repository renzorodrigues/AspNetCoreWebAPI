using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class AttendedMap : IAutoMappingOverride<Attended>
    {
        public void Override(AutoMapping<Attended> mapping)
        {
            mapping.References(x => x.Contact).Not.LazyLoad().Cascade.All();
            mapping.References(x => x.Tutor).Not.LazyLoad().Cascade.All();
        }
    }
}