using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.CQRS.Queries
{
    public class GetTaskDetailQuery : IRequest<DetailedTaskDto>
    {
        public int Id { get; set; }
    }
}
