using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.CQRS.Commands
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
        public UpdateTaskDto TaskDto { get; set; }
    }
}
