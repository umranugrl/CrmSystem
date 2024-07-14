using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface ICustomerRepository : IAsyncRepository<Customer, int>, IRepository<Customer, int>
    {
        Task<bool> AnyAsync(Expression<Func<Customer, bool>> predicate);
        Task<IEnumerable<Customer>> GetListNotPagedAsync();
        Task<Customer> GetByIdAsync(int id);
    }
}