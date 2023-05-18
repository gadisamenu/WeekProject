using MediatR;

namespace Application.Features.CheckLists.CQRS.Commands
{
    public class DeleteCheckListCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
