using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Queries;
using Application.Features.CheckLists.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Handlers
{
    public class GetCheckListDetailQueryHandler: IRequestHandler<GetCheckListDetailQuery, CheckListDto>
    {
        private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCheckListDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CheckListDto> Handle(GetCheckListDetailQuery request, CancellationToken cancellationToken)
    {
        var checkList = await _unitOfWork.CheckListRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CheckListDto>(checkList);
    }
}
}
