using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.DTOs;
using MediatR;

namespace Application.Features.Opportunities.Queries.GetAll
{
    public class GetAllOpportunityQuery : IRequest<List<OpportunityDto>>
    {
        public class GetAllOpportunityQueryHandler : IRequestHandler<GetAllOpportunityQuery, List<OpportunityDto>>
        {
            private readonly IOpportunityRepository _opportunityRepository;
            private readonly IMapper _mapper;

            public GetAllOpportunityQueryHandler(IOpportunityRepository opportunityRepository, IMapper mapper)
            {
                _opportunityRepository = opportunityRepository;
                _mapper = mapper;
            }

            public async Task<List<OpportunityDto>> Handle(GetAllOpportunityQuery request, CancellationToken cancellationToken)
            {
                var opportunities = await _opportunityRepository.GetListNotPagedAsync();
                return _mapper.Map<List<OpportunityDto>>(opportunities);
            }
        }
    }
}