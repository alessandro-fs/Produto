﻿using System.Collections.Generic;

namespace Produto.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
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
