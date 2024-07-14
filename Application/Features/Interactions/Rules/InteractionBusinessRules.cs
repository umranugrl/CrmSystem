using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;

namespace Application.Features.Interactions.Rules
{
    public class InteractionBusinessRules : BaseBusinessRules
    {
        private readonly IInteractionRepository _interactionRepository;

        public InteractionBusinessRules(IInteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async Task DuplicateInteractionCheckAsync(string interactionType, int customerId)
        {
            var check = await _interactionRepository.AnyAsync(x => x.InteractionType == interactionType && x.CustomerId == customerId);
            if (check)
            {
                throw new BusinessException("This interaction already exists for the customer.");
            }
        }
    }
}