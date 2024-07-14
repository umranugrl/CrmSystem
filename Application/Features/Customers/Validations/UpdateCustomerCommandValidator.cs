using Application.Features.Customers.Commands.Update;
using FluentValidation;

namespace Application.Features.Customers.Validations
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Customer name cannot be empty.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number cannot be empty.");
        }
    }
}