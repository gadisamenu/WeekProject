using FluentValidation;

namespace Application.Features.Tasks.Dtos.Validators
{
    public class UpdateTaskDtoValidator: AbstractValidator<UpdateTaskDto>
    {
 
        public UpdateTaskDtoValidator()
        {
            Include(new ITaskDtoValidator());

            RuleFor(p => p.Id)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");
        }
   
    }
}
