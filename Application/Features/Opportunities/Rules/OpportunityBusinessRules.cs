using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;

namespace Application.Features.Opportunities.Rules
{
    public class OpportunityBusinessRules : BaseBusinessRules
    {
        private readonly IOpportunityRepository _opportunityRepository;

        public OpportunityBusinessRules(IOpportunityRepository opportunityRepository)
        {
            _opportunityRepository = opportunityRepository;
        }

        public async Task DuplicateOpportunityNameCheckAsync(string opportunityName)
        {
            var check = await _opportunityRepository.AnyAsync(x => x.OpportunityName == opportunityName);
            if (check)
            {
                throw new BusinessException("This opportunity name is already in use.");
            }
        }
    }
}