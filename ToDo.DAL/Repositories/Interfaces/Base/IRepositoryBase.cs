using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace ToDo.DAL.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T>
        where T : class
    {

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        void Delete(T entity);

        void Update(T entity);

        Task<T> CreateAsync(T entity);
        
        Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? predicate = default,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = default);
        
    }
}