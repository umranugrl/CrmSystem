using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public interface IRequestService
    {
        Task<Request> GetAsync(int requestId, Func<IQueryable<Request>, IIncludableQueryable<Request, object>>? include = null, bool enableTracking = true);
        Task<Request> UpdateAsync(Request request);
        Task<Request> AddAsync(Request request);
        Task DeleteAsync(int requestId);
    }
}