using System;
using System.Collections.Generic;
using Produto.Domain.Interfaces.Repositories;
using Produto.Domain.Interfaces.Services;
namespace Produto.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _reprository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _reprository = repository;
        }

        public void Add(TEntity obj)
        {
            _reprository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _reprository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _reprository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _reprository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _reprository.Update(obj);
        }

        public void BeginTransaction()
        {
            _reprository.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _reprository.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _reprository.RollbackTransaction();
        }

        public void Dispose()
        {
            _reprository.Dispose();
        }
    }
}
