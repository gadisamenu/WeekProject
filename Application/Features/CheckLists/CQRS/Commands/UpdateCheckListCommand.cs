using Application.Features.CheckLists.Dtos;
using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Commands
{
    public class UpdateCheckListCommand : IRequest<Unit>
    {
        public UpdateCheckListDto CheckListDto { get; set; }
    }
}
