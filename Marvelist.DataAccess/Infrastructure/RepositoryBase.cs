using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Marvelist.DataAccess.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
        private MarvelEntities _dataContext;
        protected readonly IDbSet<T> Dbset;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            Dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected MarvelEntities DataContext => _dataContext ?? (_dataContext = DatabaseFactory.Get());

        public virtual T Add(T entity)
        {
            Dbset.Add(entity);
            return entity;
        }
        public virtual void Delete(T entity)
        {
            Dbset.Remove(entity);
        }
        public virtual T GetById(int id)
        {
            return Dbset.Find(id);
        }

        public virtual List<T> GetAll()
        {
            return Dbset.ToList();
        }
    }
}
