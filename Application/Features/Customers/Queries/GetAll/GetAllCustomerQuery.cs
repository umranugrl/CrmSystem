using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.DTOs;
using MediatR;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomerQuery : IRequest<List<CustomerDto>>
    {
        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerDto>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetAllCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var customers = await _customerRepository.GetListNotPagedAsync();
                return _mapper.Map<List<CustomerDto>>(customers);
            }
        }
    }
}