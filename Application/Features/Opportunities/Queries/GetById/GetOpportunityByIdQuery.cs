using Application.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Opportunities.Queries.GetById
{
    public class GetOpportunityByIdQuery : IRequest<GetOpportunityByIdResponse>
    {
        public int Id { get; set; }

        public class GetOpportunityByIdQueryHandler : IRequestHandler<GetOpportunityByIdQuery, GetOpportunityByIdResponse>
        {
            private readonly IOpportunityRepository _opportunityRepository;
            private readonly IMapper _mapper;

            public GetOpportunityByIdQueryHandler(IOpportunityRepository opportunityRepository, IMapper mapper)
            {
                _opportunityRepository = opportunityRepository;
                _mapper = mapper;
            }

            public async Task<GetOpportunityByIdResponse> Handle(GetOpportunityByIdQuery request, CancellationToken cancellationToken)
            {
                var opportunity = await _opportunityRepository.GetByIdAsync(request.Id);
                if (opportunity == null)
                {
                    return null;
                }

                return _mapper.Map<GetOpportunityByIdResponse>(opportunity);
            }
        }
    }
}