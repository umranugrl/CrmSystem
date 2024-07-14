using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IRequestRepository : IAsyncRepository<Request, int>, IRepository<Request, int>
    {
        Task<bool> AnyAsync(Expression<Func<Request, bool>> predicate);
        Task<IEnumerable<Request>> GetListNotPagedAsync();
        Task<Request> GetByIdAsync(int id);
    }
}