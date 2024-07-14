using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public interface IOpportunityService
    {
        Task<Opportunity> GetAsync(int opportunityId, Func<IQueryable<Opportunity>, IIncludableQueryable<Opportunity, object>>? include = null, bool enableTracking = true);
        Task<Opportunity> UpdateAsync(Opportunity opportunity);
        Task<Opportunity> AddAsync(Opportunity opportunity);
        Task DeleteAsync(int opportunityId);
    }
}