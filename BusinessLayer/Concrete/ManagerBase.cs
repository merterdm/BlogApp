﻿using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        RepositoryBase<T> repository;
        public ManagerBase()
        {
            repository = new RepositoryBase<T>();
        }
        public async Task<int> CreateAsync(T entity)
        {
            return await repository.CreateAsync(entity);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await repository.DeleteAsync(entity);
        }

        public async Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>>? filter = null)
        {
            return await repository.FindAllAsnyc(filter);
        }

        public async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? include)
        {
            return await repository.FindAllIncludeAsync(filter, include);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>>? filter = null)
        {
            return await repository.FindAsync(filter);
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<ICollection<T>> RawSqlQuery(T entity, string sql)
        {
            return await repository.RawSqlQuery(entity, sql);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            return await repository.UpdateAsync(entity);
        }
    }
}