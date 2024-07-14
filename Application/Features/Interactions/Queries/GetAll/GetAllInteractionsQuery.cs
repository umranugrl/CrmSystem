using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.DTOs;
using MediatR;

namespace Application.Features.Interactions.Queries.GetAll
{
    public class GetAllInteractionQuery : IRequest<List<InteractionDto>>
    {
        public class GetAllInteractionQueryHandler : IRequestHandler<GetAllInteractionQuery, List<InteractionDto>>
        {
            private readonly IInteractionRepository _interactionRepository;
            private readonly IMapper _mapper;

            public GetAllInteractionQueryHandler(IInteractionRepository interactionRepository, IMapper mapper)
            {
                _interactionRepository = interactionRepository;
                _mapper = mapper;
            }

            public async Task<List<InteractionDto>> Handle(GetAllInteractionQuery request, CancellationToken cancellationToken)
            {
                var interactions = await _interactionRepository.GetListNotPagedAsync();
                return _mapper.Map<List<InteractionDto>>(interactions);
            }
        }
    }
}