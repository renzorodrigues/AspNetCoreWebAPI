using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class ContacttMap : IAutoMappingOverride< Contact>
    {
        public void Override(AutoMapping<Contact> mapping)
        {
            
        }
    }
}