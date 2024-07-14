using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public interface IInteractionService
    {
        Task<Interaction> GetAsync(int interactionId, Func<IQueryable<Interaction>, IIncludableQueryable<Interaction, object>>? include = null, bool enableTracking = true);
        Task<Interaction> UpdateAsync(Interaction interaction);
        Task<Interaction> AddAsync(Interaction interaction);
        Task DeleteAsync(int interactionId);
    }
}