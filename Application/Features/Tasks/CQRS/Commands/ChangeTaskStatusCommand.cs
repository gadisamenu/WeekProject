using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.CQRS.Commands
{
    public class ChangeTaskStatusCommand : IRequest<Unit>
    {
        public ChangeTaskStatusDto TaskDto { get; set; }
    }
}
