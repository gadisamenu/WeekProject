using FluentValidation;

namespace Application.Features.Tasks.Dtos.Validators
{
    public class ITaskDtoValidator:AbstractValidator<ITaskDto>
    {
    
        public ITaskDtoValidator()
        {

        RuleFor(p => p.Description)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();

        RuleFor(p => p.StartDate)
                .NotNull()
                .LessThanOrEqualTo (p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue},StartDate should be earlier than EndDate");

        RuleFor(p => p.EndDate)
                .NotNull()
                .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue},StartDate should be earlier than EndDate");

    }
    }
}
