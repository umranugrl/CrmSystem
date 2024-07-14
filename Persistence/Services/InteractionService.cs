using Application.Repositories;
using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;
using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;

        public InteractionService(IInteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async Task<Interaction> GetAsync(int interactionId, Func<IQueryable<Interaction>, IIncludableQueryable<Interaction, object>>? include = null, bool enableTracking = true)
        {
            Interaction interaction = await _interactionRepository.GetAsync(x => x.Id == interactionId);

            if (interaction is null)
            {
                throw new BusinessException("Etkileşim mevcut değil.");
            }
            return interaction;
        }

        public async Task<Interaction> UpdateAsync(Interaction interaction)
        {
            await _interactionRepository.UpdateAsync(interaction);
            return interaction;
        }

        public async Task<Interaction> AddAsync(Interaction interaction)
        {
            await _interactionRepository.AddAsync(interaction);
            return interaction;
        }

        public async Task DeleteAsync(int interactionId)
        {
            var interaction = await _interactionRepository.GetAsync(x => x.Id == interactionId);
            if (interaction == null)
            {
                throw new BusinessException("Etkileşim mevcut değil.");
            }
            await _interactionRepository.DeleteAsync(interaction);
        }
    }
}