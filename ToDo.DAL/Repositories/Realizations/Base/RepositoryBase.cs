using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ToDo.DAL.Persistence;
using ToDo.DAL.Repositories.Interfaces.Base;

namespace ToDo.DAL.Repositories.Realizations.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly ToDoDbContext _dbContext;

        public RepositoryBase(ToDoDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            var query = GetQueryable(predicate, include).AsNoTracking();
            return await query.ToListAsync();
        }


        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public async Task<T> CreateAsync(T entity)
        {
            var entry = await _dbContext.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public async Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? predicate = default,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default)
        {
            return await GetQueryable(predicate, include).FirstOrDefaultAsync();
        }

        private IQueryable<T> GetQueryable(
            Expression<Func<T, bool>>? predicate = default,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default,
            Expression<Func<T, T>>? selector = default)
        {
            var query = _dbContext.Set<T>().AsNoTracking();

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (selector is not null)
            {
                query = query.Select(selector);
            }

            return query.AsNoTracking();
        }

        // private IQueryable<T> GetQueryable(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        // {
        //     IQueryable<T> query = _dbContext.Set<T>();
        //     if (include != null)
        //         query = include(query);
        //     return query;
        // }
    }
}