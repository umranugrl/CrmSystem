using Application.Features.Opportunities.Commands.Update;
using FluentValidation;

namespace Application.Features.Opportunities.Validations
{
    public class UpdateOpportunityCommandValidator : AbstractValidator<UpdateOpportunityCommand>
    {
        public UpdateOpportunityCommandValidator()
        {
            RuleFor(x => x.OpportunityName).NotEmpty().WithMessage("Opportunity name cannot be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty.");
            RuleFor(x => x.EstimatedValue).GreaterThan(0).WithMessage("Estimated value must be greater than zero.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status cannot be empty.");
        }
    }
}