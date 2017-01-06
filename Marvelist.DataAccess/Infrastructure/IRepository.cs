﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Marvelist.DataAccess.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteMany(Expression<Func<T, bool>> where);

        IQueryable<T> Query(Expression<Func<T, bool>> where);
    }
}