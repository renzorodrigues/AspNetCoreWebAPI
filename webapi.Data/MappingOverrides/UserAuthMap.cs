using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class UserAuthMap : IAutoMappingOverride<UserAuth>
    {
        public void Override(AutoMapping<UserAuth> mapping)
        {
            
        }
    }
}