using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.DTOs;
using MediatR;

namespace Application.Features.Interactions.Queries.GetById
{
    public class GetInteractionByIdQuery : IRequest<GetInteractionByIdResponse>
    {
        public int Id { get; set; }

        public class GetInteractionByIdQueryHandler : IRequestHandler<GetInteractionByIdQuery, GetInteractionByIdResponse>
        {
            private readonly IInteractionRepository _interactionRepository;
            private readonly IMapper _mapper;

            public GetInteractionByIdQueryHandler(IInteractionRepository interactionRepository, IMapper mapper)
            {
                _interactionRepository = interactionRepository;
                _mapper = mapper;
            }

            public async Task<GetInteractionByIdResponse> Handle(GetInteractionByIdQuery request, CancellationToken cancellationToken)
            {
                var interaction = await _interactionRepository.GetByIdAsync(request.Id);
                if (interaction == null)
                {
                    return null;
                }

                return _mapper.Map<GetInteractionByIdResponse>(interaction);
            }
        }
    }
}
