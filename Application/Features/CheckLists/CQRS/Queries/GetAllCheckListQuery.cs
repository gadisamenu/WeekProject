using Application.Features.CheckLists.Dtos;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Queries
{
    public class GetAllCheckListQuery : IRequest<List<CheckListDto>>
    { }
}
