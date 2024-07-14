using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;

namespace Application.Features.Requests.Rules
{
    public class RequestBusinessRules : BaseBusinessRules
    {
        private readonly IRequestRepository _requestRepository;

        public RequestBusinessRules(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task DuplicateRequestTypeCheckAsync(string requestType, int customerId)
        {
            var check = await _requestRepository.AnyAsync(x => x.RequestType == requestType && x.CustomerId == customerId);
            if (check)
            {
                throw new BusinessException("This request type is already in use for this customer.");
            }
        }
    }
}