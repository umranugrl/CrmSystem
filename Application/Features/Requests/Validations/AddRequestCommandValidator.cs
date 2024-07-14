using Application.Features.Requests.Commands.Add;
using FluentValidation;

namespace Application.Features.Requests.Validations
{
    public class AddRequestCommandValidator : AbstractValidator<AddRequestCommand>
    {
        public AddRequestCommandValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Invalid customer ID.");
            RuleFor(x => x.RequestType).NotEmpty().WithMessage("Request type cannot be empty.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Details cannot be empty.");
        }
    }
}