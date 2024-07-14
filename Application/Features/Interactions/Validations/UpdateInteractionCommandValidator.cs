using Application.Features.Interactions.Commands.Update;
using FluentValidation;

namespace Application.Features.Interactions.Validations
{
    public class UpdateInteractionCommandValidator : AbstractValidator<UpdateInteractionCommand>
    {
        public UpdateInteractionCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid interaction ID.");
            RuleFor(x => x.CustomerID).GreaterThan(0).WithMessage("Invalid customer ID.");
            RuleFor(x => x.InteractionType).NotEmpty().WithMessage("Interaction type cannot be empty.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Details cannot be empty.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date cannot be empty.");
        }
    }
}