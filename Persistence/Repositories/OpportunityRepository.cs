using Application.Repositories;
using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using crmSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class OpportunityRepository : EfRepositoryBase<Opportunity, int, CrmDbContext>, IOpportunityRepository
    {
        private readonly CrmDbContext _context;
        public OpportunityRepository(CrmDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<Opportunity, bool>> predicate)
        {
            return await _context.Set<Opportunity>().AnyAsync(predicate);
        }

        public async Task<Opportunity> GetByIdAsync(int id)
        {
            return await _context.Set<Opportunity>().FindAsync(id);
        }

        public async Task<IEnumerable<Opportunity>> GetListNotPagedAsync()
        {
            return await _context.Set<Opportunity>().ToListAsync();
        }
    }
}