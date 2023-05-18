using Application.Contracts.Presistence;
using Application.Features.Tasks.CQRS.Queries;
using Application.Features.Tasks.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Tasks.CQRS.Handlers
{
    public class GetTaskDetailQueryHandler : IRequestHandler<GetTaskDetailQuery, TaskDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTaskDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(GetTaskDetailQuery request, CancellationToken cancellationToken)
        {
            var Task = await _unitOfWork.TaskRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TaskDto>(Task);
        }
    }
}