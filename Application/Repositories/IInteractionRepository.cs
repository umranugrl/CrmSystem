using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IInteractionRepository : IAsyncRepository<Interaction, int>, IRepository<Interaction, int>
    {
        Task<bool> AnyAsync(Expression<Func<Interaction, bool>> predicate);
        Task<IEnumerable<Interaction>> GetListNotPagedAsync();
        Task<Interaction> GetByIdAsync(int id);
    }
}