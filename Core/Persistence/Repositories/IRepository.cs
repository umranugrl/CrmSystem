using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
    }
}