using Application.Repositories;
using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;
using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly IOpportunityRepository _opportunityRepository;

        public OpportunityService(IOpportunityRepository opportunityRepository)
        {
            _opportunityRepository = opportunityRepository;
        }

        public async Task<Opportunity> GetAsync(int opportunityId, Func<IQueryable<Opportunity>, IIncludableQueryable<Opportunity, object>>? include = null, bool enableTracking = true)
        {
            Opportunity opportunity = await _opportunityRepository.GetAsync(x => x.Id == opportunityId);

            if (opportunity is null)
            {
                throw new BusinessException("Satış fırsatı mevcut değil.");
            }
            return opportunity;
        }

        public async Task<Opportunity> UpdateAsync(Opportunity opportunity)
        {
            await _opportunityRepository.UpdateAsync(opportunity);
            return opportunity;
        }

        public async Task<Opportunity> AddAsync(Opportunity opportunity)
        {
            await _opportunityRepository.AddAsync(opportunity);
            return opportunity;
        }

        public async Task DeleteAsync(int opportunityId)
        {
            var opportunity = await _opportunityRepository.GetAsync(x => x.Id == opportunityId);
            if (opportunity == null)
            {
                throw new BusinessException("Satış fırsatı mevcut değil.");
            }
            await _opportunityRepository.DeleteAsync(opportunity);
        }
    }
}