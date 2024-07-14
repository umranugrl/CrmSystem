using Application.Repositories;
using MediatR;

namespace Application.Features.Interactions.Commands.Delete
{
    public class DeleteInteractionCommand : IRequest<DeleteInteractionResponse>
    {
        public int Id { get; set; }
    }

    public class DeleteInteractionCommandHandler : IRequestHandler<DeleteInteractionCommand, DeleteInteractionResponse>
    {
        private readonly IInteractionRepository _interactionRepository;

        public DeleteInteractionCommandHandler(IInteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async Task<DeleteInteractionResponse> Handle(DeleteInteractionCommand request, CancellationToken cancellationToken)
        {
            var interaction = await _interactionRepository.GetByIdAsync(request.Id);
            if (interaction == null)
            {
                return new DeleteInteractionResponse
                {
                    Success = false,
                    Message = "Interaction not found"
                };
            }

            await _interactionRepository.DeleteAsync(interaction);
            return new DeleteInteractionResponse
            {
                Success = true,
                Message = "Interaction deleted successfully"
            };
        }
    }
}