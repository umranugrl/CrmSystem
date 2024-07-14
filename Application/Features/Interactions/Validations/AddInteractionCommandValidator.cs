using Application.Features.Interactions.Commands.Add;
using FluentValidation;

namespace Application.Features.Interactions.Validations
{
    public class AddInteractionCommandValidator : AbstractValidator<AddInteractionCommand>
    {
        public AddInteractionCommandValidator()
        {
            RuleFor(x => x.CustomerID).GreaterThan(0).WithMessage("Invalid customer ID.");
            RuleFor(x => x.InteractionType).NotEmpty().WithMessage("Interaction type cannot be empty.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Details cannot be empty.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date cannot be empty.");
        }
    }
}