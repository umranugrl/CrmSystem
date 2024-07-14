using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.Entities;
using MediatR;

namespace Application.Features.Opportunities.Commands.Add
{
    public class AddOpportunityCommand : IRequest<AddOpportunityResponse>
    {
        public int CustomerId { get; set; }
        public string OpportunityName { get; set; }
        public string Description { get; set; }
        public decimal EstimatedValue { get; set; }
        public string Status { get; set; }

        public class AddOpportunityCommandHandler : IRequestHandler<AddOpportunityCommand, AddOpportunityResponse>
        {
            private readonly IOpportunityRepository _opportunityRepository;
            private readonly IMapper _mapper;

            public AddOpportunityCommandHandler(IOpportunityRepository opportunityRepository, IMapper mapper)
            {
                _opportunityRepository = opportunityRepository;
                _mapper = mapper;
            }

            public async Task<AddOpportunityResponse> Handle(AddOpportunityCommand request, CancellationToken cancellationToken)
            {
                var opportunity = _mapper.Map<Opportunity>(request);
                await _opportunityRepository.AddAsync(opportunity);
                return _mapper.Map<AddOpportunityResponse>(opportunity);
            }
        }
    }
}