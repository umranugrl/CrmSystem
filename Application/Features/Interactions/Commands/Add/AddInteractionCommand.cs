using Application.Repositories;
using AutoMapper;
using crmSystem.Domain.Entities;
using MediatR;

namespace Application.Features.Interactions.Commands.Add
{
    public class AddInteractionCommand : IRequest<AddInteractionResponse>
    {
        public int CustomerID { get; set; }
        public string InteractionType { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public class AddInteractionCommandHandler : IRequestHandler<AddInteractionCommand, AddInteractionResponse>
        {
            private readonly IInteractionRepository _interactionRepository;
            private readonly IMapper _mapper;

            public AddInteractionCommandHandler(IInteractionRepository interactionRepository, IMapper mapper)
            {
                _interactionRepository = interactionRepository;
                _mapper = mapper;
            }

            public async Task<AddInteractionResponse> Handle(AddInteractionCommand request, CancellationToken cancellationToken)
            {
                var interaction = _mapper.Map<Interaction>(request);
                await _interactionRepository.AddAsync(interaction);
                return _mapper.Map<AddInteractionResponse>(interaction);
            }
        }
    }
}