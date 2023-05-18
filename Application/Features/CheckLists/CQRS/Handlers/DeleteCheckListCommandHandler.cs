using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Commands;
using Application.Features.Tasks.CQRS.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Handlers
{
    public class DeleteCheckListCommandHandler: IRequestHandler<DeleteCheckListCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCheckListCommandHandler(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;

            _mapper = Mapper;
        }
        public async Task<Unit> Handle(DeleteCheckListCommand request, CancellationToken cancellationToken)
        {
            var checkList = await _unitOfWork.CheckListRepository.GetByIdAsync(request.Id);

            if (checkList == null) throw new NotFoundException("CheckList not found");

             _unitOfWork.CheckListRepository.DeleteAsync(checkList);

            if (await _unitOfWork.Save() == 0) throw new AppException("Server error: couldn't save data");

            return Unit.Value;
        }
    }
}
