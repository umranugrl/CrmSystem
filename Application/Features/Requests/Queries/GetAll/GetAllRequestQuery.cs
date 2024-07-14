using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.DTOs;
using MediatR;

namespace Application.Features.Requests.Queries.GetAll
{
    public class GetAllRequestQuery : IRequest<List<RequestDto>>
    {
        public class GetAllRequestQueryHandler : IRequestHandler<GetAllRequestQuery, List<RequestDto>>
        {
            private readonly IRequestRepository _requestRepository;
            private readonly IMapper _mapper;

            public GetAllRequestQueryHandler(IRequestRepository requestRepository, IMapper mapper)
            {
                _requestRepository = requestRepository;
                _mapper = mapper;
            }

            public async Task<List<RequestDto>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
            {
                var requests = await _requestRepository.GetListNotPagedAsync();
                return _mapper.Map<List<RequestDto>>(requests);
            }
        }
    }
}