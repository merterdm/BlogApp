using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        public RepositoryBase()
        {
            _context = new SqlContext();
        }
        public SqlContext _context { get; set; }

        public virtual async Task<int> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<int> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
        public virtual async Task<T>? GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await _context.Set<T>().Where(filter).FirstOrDefaultAsync();
            else
                return await _context.Set<T>().FirstOrDefaultAsync();
        }

        public virtual async Task<IList<T>> FindAllAsnyc(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await _context.Set<T>().Where(filter).ToListAsync();
            else
                return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            var query = _context.Set<T>();
            if (filter != null)
            {
                query.Where(filter);
            }
            var result = include.Aggregate(query.AsQueryable(),
                                    (current, includeprop) => current.Include(includeprop));
            return result;
        }

        public virtual async Task<ICollection<T>> RawSqlQuery(T entity, string sql)
        {
            var result = _context.Set<T>().FromSqlRaw(sql);
            return await result.ToListAsync();
        }
    }
}
