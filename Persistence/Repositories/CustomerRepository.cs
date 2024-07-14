using Application.Repositories;
using Core.Persistence.Repositories;
using crmSystem.Domain.Entities;
using crmSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class CustomerRepository : EfRepositoryBase<Customer, int, CrmDbContext>, ICustomerRepository
    {
        private readonly CrmDbContext _context;
        public CustomerRepository(CrmDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Set<Customer>().AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Set<Customer>().Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customer customer)
        {
            _context.Set<Customer>().Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Set<Customer>().Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Set<Customer>().AnyAsync(predicate);
        }

        public async Task<IEnumerable<Customer>> GetListNotPagedAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }

        public Customer GetById(int id)
        {
            return _context.Set<Customer>().Find(id);
        }

        public void Add(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _context.Set<Customer>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Set<Customer>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Set<Customer>().ToList();
        }

        public IEnumerable<Customer> Get(Expression<Func<Customer, bool>> predicate)
        {
            return _context.Set<Customer>().Where(predicate).ToList();
        }
    }
}