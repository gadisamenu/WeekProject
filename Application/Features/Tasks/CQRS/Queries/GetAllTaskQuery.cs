using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.CQRS.Queries
{
    public class GetTaskDetailQuery : IRequest<TaskDto>
    {
        public int Id { get; set; }
    }
}
