using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.CQRS.Queries
{
    public class GetAllTaskQuery : IRequest<List<TaskDto>>
    { }
}
