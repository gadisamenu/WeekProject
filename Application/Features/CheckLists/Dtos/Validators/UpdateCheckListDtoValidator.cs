using FluentValidation;

namespace Application.Features.CheckLists.Dtos.Validators
{
    public class UpdateCheckListDtoValidator: AbstractValidator<UpdateCheckListDto>
    {
 
        public UpdateCheckListDtoValidator()
        {
            Include(new ICheckListDtoValidator());

            RuleFor(p => p.Id)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");
        }
   
    }
}
