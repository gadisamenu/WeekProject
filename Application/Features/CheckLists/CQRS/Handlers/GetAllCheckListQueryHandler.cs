using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Queries;
using Application.Features.CheckLists.Dtos;
using Application.Features.Tasks.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CheckLists.CQRS.Handlers
{
    public class GetAllCheckListQueryHandler:IRequestHandler<GetAllCheckListQuery,List<CheckListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCheckListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CheckListDto>> Handle(GetAllCheckListQuery request, CancellationToken cancellationToken)
        {
            var checkLists = await _unitOfWork.CheckListRepository.GetAllAsync();
            return _mapper.Map<List<CheckListDto>>(checkLists);
        }
    }
}
