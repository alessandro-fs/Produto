using System.Collections.Generic;

namespace Produto.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllAsNoTracking();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
