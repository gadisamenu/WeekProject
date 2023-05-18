using FluentValidation;

namespace Application.Features.CheckLists.Dtos.Validators
{
    public class ICheckListDtoValidator:AbstractValidator<ICheckListDto>
    {
    
        public ICheckListDtoValidator()
        {
            
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Description)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();

        }
    }
}
