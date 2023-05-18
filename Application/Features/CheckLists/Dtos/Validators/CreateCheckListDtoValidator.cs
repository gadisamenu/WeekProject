using Application.Contracts.Presistence;
using FluentValidation;

namespace Application.Features.CheckLists.Dtos.Validators
{
    public class CreateCheckListDtoValidator:AbstractValidator<CreateCheckListDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public  CreateCheckListDtoValidator(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;

            Include(new ICheckListDtoValidator());
            RuleFor(p => p.Completed)
                .Must((cmpld) => cmpld.GetType() == typeof(bool))
                .WithMessage("{ProperyName} must be boolean");

            RuleFor(p => p.TaskId)
                .GreaterThan(0)
                .MustAsync(async (id, token) => await _unitOfWork.TaskRepository.Exists(id))
                .WithMessage("{PropertyName} doesn't exist");
        }
    }
}
