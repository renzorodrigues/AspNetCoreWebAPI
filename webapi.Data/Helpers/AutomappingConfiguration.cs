using System;
using FluentNHibernate.Automapping;
using webapi.Domain.Entities;

namespace webapi.Data.Helpers
{
    public class AutomappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterface(typeof(IEntity).FullName) != null;
        }
    }
}