using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class AuthMap : IAutoMappingOverride<Auth>
    {
        public void Override(AutoMapping<Auth> mapping)
        {
            
        }
    }
}