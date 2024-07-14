using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;

namespace Application.Features.Customers.Rules
{
    public class CustomerBusinessRules : BaseBusinessRules
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBusinessRules(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task DuplicateEmailCheckAsync(string email)
        {
            var check = await _customerRepository.AnyAsync(x => x.Email == email);
            if (check)
            {
                throw new BusinessException("This email is already in use.");
            }
        }
    }
}