using Application.Features.CheckLists.Dtos;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Commands
{
    public class ChangeCheckListStatusCommand : IRequest<Unit>
    {
        public ChangeCheckListStatusDto CheckListDto { get; set; }
    }
}
