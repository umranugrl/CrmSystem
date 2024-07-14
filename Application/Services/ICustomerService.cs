using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetAsync(int customerId, Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null, bool enableTracking = true);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer> AddAsync(Customer customer);
        Task DeleteAsync(int customerId);
    }
}