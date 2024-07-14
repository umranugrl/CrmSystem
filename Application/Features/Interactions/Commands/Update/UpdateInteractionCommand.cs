using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Interactions.Commands.Update
{
    public class UpdateInteractionCommand : IRequest<UpdateInteractionResponse>
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string InteractionType { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }

        public class UpdateInteractionCommandHandler : IRequestHandler<UpdateInteractionCommand, UpdateInteractionResponse>
        {
            private readonly IInteractionRepository _interactionRepository;
            private readonly IMapper _mapper;

            public UpdateInteractionCommandHandler(IInteractionRepository interactionRepository, IMapper mapper)
            {
                _interactionRepository = interactionRepository;
                _mapper = mapper;
            }

            public async Task<UpdateInteractionResponse> Handle(UpdateInteractionCommand request, CancellationToken cancellationToken)
            {
                var interaction = await _interactionRepository.GetByIdAsync(request.Id);
                if (interaction == null)
                {
                    return new UpdateInteractionResponse
                    {
                        Success = false,
                        Message = "Interaction not found"
                    };
                }

                _mapper.Map(request, interaction);
                await _interactionRepository.UpdateAsync(interaction);
                return new UpdateInteractionResponse
                {
                    Success = true,
                    Message = "Interaction updated successfully"
                };
            }
        }
    }
}