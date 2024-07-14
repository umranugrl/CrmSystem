using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<TEntity, TKey>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}