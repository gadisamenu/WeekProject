using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.Tasks.CQRS.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Tasks.CQRS.Handlers
{
    public class DeleteTaskCommandHandler: IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTaskCommandHandler(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;

            _mapper = Mapper;
        }
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var Task = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);

            if (Task == null) throw new NotFoundException("Task not found");

            _unitOfWork.TaskRepository.DeleteAsync(Task);

            if (await _unitOfWork.Save() == 0) throw new AppException("Server error: couldn't save data");

            return Unit.Value;
        }
    }
}
