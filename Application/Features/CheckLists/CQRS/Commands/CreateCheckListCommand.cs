using Application.Features.CheckLists.Dtos;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Commands
{
    public class CreateCheckListCommand : IRequest<int>
    {
        public CreateCheckListDto CheckListDto { get; set; }
    }
}
