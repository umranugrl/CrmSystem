using Application.Features.Opportunities.Commands.Delete;
using FluentValidation;

namespace Application.Features.Opportunities.Validations
{
    public class DeleteOpportunityCommandValidator : AbstractValidator<DeleteOpportunityCommand>
    {
        public DeleteOpportunityCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
        }
    }
}