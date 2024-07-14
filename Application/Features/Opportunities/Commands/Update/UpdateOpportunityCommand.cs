using Application.Repositories;
using crmSystem.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Opportunities.Commands.Update
{
    public class UpdateOpportunityCommand : IRequest<UpdateOpportunityResponse>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string OpportunityName { get; set; }
        public string Description { get; set; }
        public decimal EstimatedValue { get; set; }
        public string Status { get; set; }
        public class UpdateOpportunityCommandHandler : IRequestHandler<UpdateOpportunityCommand, UpdateOpportunityResponse>
        {
            private readonly IOpportunityRepository _opportunityRepository;
            private readonly IMapper _mapper;

            public UpdateOpportunityCommandHandler(IOpportunityRepository opportunityRepository, IMapper mapper)
            {
                _opportunityRepository = opportunityRepository;
                _mapper = mapper;
            }

            public async Task<UpdateOpportunityResponse> Handle(UpdateOpportunityCommand request, CancellationToken cancellationToken)
            {
                var opportunity = await _opportunityRepository.GetByIdAsync(request.Id);
                if (opportunity == null)
                {
                    return new UpdateOpportunityResponse
                    {
                        Success = false,
                        Message = "Opportunity not found"
                    };
                }

                _mapper.Map(request, opportunity);
                await _opportunityRepository.UpdateAsync(opportunity);
                return new UpdateOpportunityResponse
                {
                    Success = true,
                    Message = "Opportunity updated successfully"
                };
            }
        }
    }    
}