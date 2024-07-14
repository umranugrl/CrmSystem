using Application.Repositories;
using MediatR;

namespace Application.Features.Opportunities.Commands.Delete
{
    public class DeleteOpportunityCommand : IRequest<DeleteOpportunityResponse>
    {
        public int Id { get; set; }
        public class DeleteOpportunityCommandHandler : IRequestHandler<DeleteOpportunityCommand, DeleteOpportunityResponse>
        {
            private readonly IOpportunityRepository _opportunityRepository;

            public DeleteOpportunityCommandHandler(IOpportunityRepository opportunityRepository)
            {
                _opportunityRepository = opportunityRepository;
            }

            public async Task<DeleteOpportunityResponse> Handle(DeleteOpportunityCommand request, CancellationToken cancellationToken)
            {
                var opportunity = await _opportunityRepository.GetByIdAsync(request.Id);
                if (opportunity == null)
                {
                    return new DeleteOpportunityResponse
                    {
                        Success = false,
                        Message = "Opportunity not found"
                    };
                }

                await _opportunityRepository.DeleteAsync(opportunity);
                return new DeleteOpportunityResponse
                {
                    Success = true,
                    Message = "Opportunity deleted successfully"
                };
            }
        }
    }
}