using Application.Repositories;
using MediatR;

namespace Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                return new DeleteCustomerResponse
                {
                    Success = false,
                    Message = "Customer not found"
                };
            }

            await _customerRepository.DeleteAsync(customer);
            return new DeleteCustomerResponse
            {
                Success = true,
                Message = "Customer deleted successfully"
            };
        }
    }
}
