using Application.Features.Customers.Commands.Delete;
using FluentValidation;

namespace Application.Features.Customers.Validations
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid customer ID.");
        }
    }
}