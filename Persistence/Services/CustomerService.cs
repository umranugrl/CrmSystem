using Application.Repositories;
using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;
using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> GetAsync(int customerId, Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null, bool enableTracking = true)
        {
            Customer customer = await _customerRepository.GetAsync(x => x.Id == customerId);

            if (customer is null)
            {
                throw new BusinessException("Müşteri mevcut değil.");
            }
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
            return customer;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            return customer;
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == customerId);
            if (customer == null)
            {
                throw new BusinessException("Müşteri mevcut değil.");
            }
            await _customerRepository.DeleteAsync(customer);
        }
    }
}