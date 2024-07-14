using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.Entities;
using MediatR;

namespace Application.Features.Requests.Commands.Add
{
    public class AddRequestCommand : IRequest<AddRequestResponse>
    {
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }

        public class AddRequestCommandHandler : IRequestHandler<AddRequestCommand, AddRequestResponse>
        {
            private readonly IRequestRepository _requestRepository;
            private readonly IMapper _mapper;

            public AddRequestCommandHandler(IRequestRepository requestRepository, IMapper mapper)
            {
                _requestRepository = requestRepository;
                _mapper = mapper;
            }

            public async Task<AddRequestResponse> Handle(AddRequestCommand request, CancellationToken cancellationToken)
            {
                var requestEntity = _mapper.Map<Request>(request);
                await _requestRepository.AddAsync(requestEntity);
                return _mapper.Map<AddRequestResponse>(requestEntity);
            }
        }
    }
}