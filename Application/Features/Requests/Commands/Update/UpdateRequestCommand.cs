using Application.Repositories;
using crmSystem.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Requests.Commands.Update
{
    public class UpdateRequestCommand : IRequest<UpdateRequestResponse>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, UpdateRequestResponse>
        {
            private readonly IRequestRepository _requestRepository;
            private readonly IMapper _mapper;

            public UpdateRequestCommandHandler(IRequestRepository requestRepository, IMapper mapper)
            {
                _requestRepository = requestRepository;
                _mapper = mapper;
            }

            public async Task<UpdateRequestResponse> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
            {
                var requestEntity = await _requestRepository.GetByIdAsync(request.Id);
                if (requestEntity == null)
                {
                    return new UpdateRequestResponse
                    {
                        Success = false,
                        Message = "Request not found"
                    };
                }

                _mapper.Map(request, requestEntity);
                await _requestRepository.UpdateAsync(requestEntity);
                return new UpdateRequestResponse
                {
                    Success = true,
                    Message = "Request updated successfully"
                };
            }
        }
    }
}