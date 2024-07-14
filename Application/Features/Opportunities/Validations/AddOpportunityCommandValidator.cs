using Application.Features.Opportunities.Commands.Add;
using FluentValidation;

namespace Application.Features.Opportunities.Validations
{
    public class AddOpportunityCommandValidator : AbstractValidator<AddOpportunityCommand>
    {
        public AddOpportunityCommandValidator()
        {
            RuleFor(x => x.OpportunityName).NotEmpty().WithMessage("Opportunity name cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
            RuleFor(x => x.EstimatedValue).GreaterThan(0).WithMessage("Estimated value must be greater than zero.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status cannot be empty.");
        }
    }
}