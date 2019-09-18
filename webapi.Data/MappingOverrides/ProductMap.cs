using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using webapi.Domain.Entities;

namespace webapi.Data.MappingOverrides
{
    public class ProductMap : IAutoMappingOverride<Product>
    {
        public void Override(AutoMapping<Product> mapping)
        {
            
        }
    }
}