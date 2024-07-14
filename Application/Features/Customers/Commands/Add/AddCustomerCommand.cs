using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.Add
{
    public class AddCustomerCommand : IRequest<AddCustomerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, AddCustomerResponse>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public AddCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<AddCustomerResponse> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<Customer>(request);
                await _customerRepository.AddAsync(customer);
                return _mapper.Map<AddCustomerResponse>(customer);
            }
        }
    }
}