using Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Requests.Queries.GetById
{
    public class GetRequestByIdQuery : IRequest<GetRequestByIdResponse>
    {
        public int Id { get; set; }

        public class GetRequestByIdQueryHandler : IRequestHandler<GetRequestByIdQuery, GetRequestByIdResponse>
        {
            private readonly IRequestRepository _requestRepository;
            private readonly IMapper _mapper;

            public GetRequestByIdQueryHandler(IRequestRepository requestRepository, IMapper mapper)
            {
                _requestRepository = requestRepository;
                _mapper = mapper;
            }

            public async Task<GetRequestByIdResponse> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
            {
                var requestEntity = await _requestRepository.GetByIdAsync(request.Id);
                if (requestEntity == null)
                {
                    return null;
                }

                return _mapper.Map<GetRequestByIdResponse>(requestEntity);
            }
        }
    }
}