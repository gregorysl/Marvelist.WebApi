using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Marvelist.DataAccess.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        T Add(T entity);
        void Delete(T entity);
        void DeleteMany(Expression<Func<T, bool>> where);
    }
}
