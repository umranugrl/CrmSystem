using Application.Features.Requests.Commands.Delete;
using FluentValidation;

namespace Application.Features.Requests.Validations
{
    public class DeleteRequestCommandValidator : AbstractValidator<DeleteRequestCommand>
    {
        public DeleteRequestCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid request ID.");
        }
    }
}