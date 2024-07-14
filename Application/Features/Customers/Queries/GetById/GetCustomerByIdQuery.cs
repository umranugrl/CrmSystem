using Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetById
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdResponse>
    {
        public int Id { get; set; }

        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;

            public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(request.Id);
                if (customer == null)
                {
                    return null; 
                }

                return _mapper.Map<GetCustomerByIdResponse>(customer);
            }
        }
    }
}