using Application.Repositories;
using MediatR;

namespace Application.Features.Requests.Commands.Delete
{
    public class DeleteRequestCommand : IRequest<DeleteRequestResponse>
    {
        public int Id { get; set; }
        public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, DeleteRequestResponse>
        {
            private readonly IRequestRepository _requestRepository;

            public DeleteRequestCommandHandler(IRequestRepository requestRepository)
            {
                _requestRepository = requestRepository;
            }

            public async Task<DeleteRequestResponse> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
            {
                var requestEntity = await _requestRepository.GetByIdAsync(request.Id);
                if (requestEntity == null)
                {
                    return new DeleteRequestResponse
                    {
                        Success = false,
                        Message = "Request not found"
                    };
                }

                await _requestRepository.DeleteAsync(requestEntity);
                return new DeleteRequestResponse
                {
                    Success = true,
                    Message = "Request deleted successfully"
                };
            }
        }
    }    
}