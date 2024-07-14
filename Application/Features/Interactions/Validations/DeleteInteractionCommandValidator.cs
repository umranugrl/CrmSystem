using Application.Features.Interactions.Commands.Delete;
using FluentValidation;

namespace Application.Features.Interactions.Validations
{
    public class DeleteInteractionCommandValidator : AbstractValidator<DeleteInteractionCommand>
    {
        public DeleteInteractionCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid interaction ID.");
        }
    }
}