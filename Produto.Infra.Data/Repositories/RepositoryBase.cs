using System;
using System.Collections.Generic;
using System.Data.Entity;
using Produto.Domain.Interfaces.Repositories;
using System.Linq;
using System.Data;

namespace Produto.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected Context.Contexto Db = new Context.Contexto();
        private System.Data.Common.DbTransaction trans;
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            if (trans != null)
                Db.Database.UseTransaction(trans);

            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            if (trans != null)
                Db.Database.UseTransaction(trans);

            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {

            Db.Set<TEntity>().Remove(obj);
            if (trans != null)
                Db.Database.UseTransaction(trans);

            Db.SaveChanges();
        }

        public void Dispose()
        {
            if (Db != null)
                Db.Dispose();
        }

        public void BeginTransaction()
        {
            Db.Database.Connection.Open();
            trans = Db.Database.Connection.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void CommitTransaction()
        {
            trans.Commit();
            CloseConnection();
        }

        public void RollbackTransaction()
        {
            trans.Rollback();
            CloseConnection();
        }

        private void CloseConnection()
        {
            if (Db.Database.Connection.State == ConnectionState.Open)
                Db.Database.Connection.Close();
        }
    }
}
