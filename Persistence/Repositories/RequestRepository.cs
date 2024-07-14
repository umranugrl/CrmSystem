using Application.Repositories;
using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using crmSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class RequestRepository : EfRepositoryBase<Request, int, CrmDbContext>, IRequestRepository
    {
        public RequestRepository(CrmDbContext context) : base(context)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<Request, bool>> predicate)
        {
            return await _context.Set<Request>().AnyAsync(predicate);
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            return await _context.Set<Request>().FindAsync(id);
        }

        public async Task<IEnumerable<Request>> GetListNotPagedAsync()
        {
            return await _context.Set<Request>().ToListAsync();
        }
    }
}