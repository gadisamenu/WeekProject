using Application.Features.CheckLists.Dtos;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Queries
{
    public class GetCheckListDetailQuery : IRequest<CheckListDto>
    {
        public int Id { get; set; }
    }
}
