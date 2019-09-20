using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Linq;
using webapi.Data.MappingOverrides;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;

namespace webapi.Data.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork() 
        {
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(
                    x => x.Server("localhost").
                    Username("root").
                    Password("123").
                    Database("ccaudb")
                ))
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<Atendido>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<AtendidoMap>()))
                .Mappings(x => x.AutoMappings.Add(AutoMap.AssemblyOf<Avaliador>(new AutomappingConfiguration()).UseOverridesFromAssemblyOf<AvaliadorMap>()))
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch 
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}