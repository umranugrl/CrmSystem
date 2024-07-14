using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IOpportunityRepository : IAsyncRepository<Opportunity, int>, IRepository<Opportunity, int>
    {
        Task<bool> AnyAsync(Expression<Func<Opportunity, bool>> predicate);
        Task<IEnumerable<Opportunity>> GetListNotPagedAsync();
        Task<Opportunity> GetByIdAsync(int id);
    }
}