using webapi.Domain.Repositories;

namespace webapi.Domain.Helpers
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}