using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.Tasks.CQRS.Commands;
using Application.Features.Tasks.Dtos.Validators;
using AutoMapper;
using MediatR;

namespace Application.Features.Tasks.CQRS.Handlers
{
    public class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeTaskStatusCommandHandler(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;

            _mapper = Mapper;
        }
        public async Task<Unit> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new ChangeTaskStatusDtoValidator();

            var validationResult = await validator.ValidateAsync(request.TaskDto);

            if (!validationResult.IsValid) throw new ValidationException("Validation error",validationResult.Errors);

            var Task = await _unitOfWork.TaskRepository.GetByIdAsync(request.TaskDto.Id);

            if (Task == null) throw new NotFoundException("Task not found");

            _mapper.Map(request.TaskDto, Task);

            if (await _unitOfWork.Save() == 0) throw new AppException("Server error: couldn't save data");

            return Unit.Value;
        }
    }
}
