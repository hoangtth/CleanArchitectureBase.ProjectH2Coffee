﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Interfaces
{
    public interface IGenericRepository <T> where T : class 
    {
        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAll();

        IEnumerable<T> Find(Expression <Func <T, bool>> expression);

        Task Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task<T?> FirstOrDefault(Expression<Func <T, bool>> expression);
    }
}
