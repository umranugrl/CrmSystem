using Application.Repositories;
using crmSystem.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                return new UpdateCustomerResponse
                {
                    Success = false,
                    Message = "Customer not found"
                };
            }

            _mapper.Map(request, customer);
            await _customerRepository.UpdateAsync(customer);
            return new UpdateCustomerResponse
            {
                Success = true,
                Message = "Customer updated successfully"
            };
        }
    }
}
