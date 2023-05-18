using Application.Contracts.Presistence;
using FluentValidation;

namespace Application.Features.Tasks.Dtos.Validators
{
    public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskDtoValidator(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;

            Include(new ITaskDtoValidator());
            RuleFor(p => p.Completed)
                .Must((cmpld) => cmpld.GetType() == typeof(bool))
                .WithMessage("{ProperyName} must be boolean");
        }
    }
}
