using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CheckLists.Dtos.Validators
{
    public class ChangeCheckListStatusDtoValidator : AbstractValidator<ChangeCheckListStatusDto>
    {

        public ChangeCheckListStatusDtoValidator()
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
