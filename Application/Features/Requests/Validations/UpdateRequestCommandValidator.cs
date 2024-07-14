using Application.Features.Requests.Commands.Update;
using FluentValidation;

namespace Application.Features.Requests.Validations
{
    public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
    {
        public UpdateRequestCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid request ID.");
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Invalid customer ID.");
            RuleFor(x => x.RequestType).NotEmpty().WithMessage("Request type cannot be empty.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Details cannot be empty.");
        }
    }
}