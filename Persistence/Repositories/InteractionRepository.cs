using Application.Repositories;
using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using crmSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class InteractionRepository : EfRepositoryBase<Interaction, int, CrmDbContext>, IInteractionRepository
    {
        public InteractionRepository(CrmDbContext context) : base(context)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<Interaction, bool>> predicate)
        {
            return await _context.Set<Interaction>().AnyAsync(predicate);
        }

        public async Task<Interaction> GetByIdAsync(int id)
        {
            return await _context.Set<Interaction>().FindAsync(id);
        }

        public async Task<IEnumerable<Interaction>> GetListNotPagedAsync()
        {
            return await _context.Set<Interaction>().ToListAsync();
        }
    }
}