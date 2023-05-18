using MediatR;

namespace Application.Features.Tasks.CQRS.Commands
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
