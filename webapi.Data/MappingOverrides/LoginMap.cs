using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class LoginMap : IAutoMappingOverride<Login>
    {
        public void Override(AutoMapping<Login> mapping)
        {
            
        }
    }
}