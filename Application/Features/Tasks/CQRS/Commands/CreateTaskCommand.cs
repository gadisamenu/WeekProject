using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.CQRS.Commands
{
    public class CreateTaskCommand : IRequest<int>
    {
        public CreateTaskDto TaskDto { get; set; }
    }
}
