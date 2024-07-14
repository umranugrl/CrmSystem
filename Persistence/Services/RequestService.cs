using Application.Repositories;
using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;
using crmSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Request> GetAsync(int requestId, Func<IQueryable<Request>, IIncludableQueryable<Request, object>>? include = null, bool enableTracking = true)
        {
            Request request = await _requestRepository.GetAsync(x => x.Id == requestId);

            if (request is null)
            {
                throw new BusinessException("İstek mevcut değil.");
            }
            return request;
        }

        public async Task<Request> UpdateAsync(Request request)
        {
            await _requestRepository.UpdateAsync(request);
            return request;
        }

        public async Task<Request> AddAsync(Request request)
        {
            await _requestRepository.AddAsync(request);
            return request;
        }

        public async Task DeleteAsync(int requestId)
        {
            var request = await _requestRepository.GetAsync(x => x.Id == requestId);
            if (request == null)
            {
                throw new BusinessException("İstek mevcut değil.");
            }
            await _requestRepository.DeleteAsync(request);
        }
    }
}