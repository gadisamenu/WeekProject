using Application.Contracts.Presistence;
using Application.Features.Tasks.CQRS.Queries;
using Application.Features.Tasks.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Tasks.CQRS.Handlers
{
    public class GetAllTaskQueryHandler:IRequestHandler<GetAllTaskQuery,List<TaskDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTaskQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var Tasks = await _unitOfWork.TaskRepository.GetALlTaskWithOwner();
            return _mapper.Map<List<TaskDto>>(Tasks);
        }
    }
}
