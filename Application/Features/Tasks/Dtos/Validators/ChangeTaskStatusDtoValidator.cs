using FluentValidation;

namespace Application.Features.Tasks.Dtos.Validators
{
    public class ChangeTaskStatusDtoValidator : AbstractValidator<ChangeTaskStatusDto>
    {

        public ChangeTaskStatusDtoValidator()
        {

            RuleFor(p => p.Id)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");
            RuleFor(p => p.Completed)
                .Must((cmpld) => cmpld.GetType() == typeof(bool))
                .WithMessage("{ProperyName} must be boolean");
        }
    }
}
