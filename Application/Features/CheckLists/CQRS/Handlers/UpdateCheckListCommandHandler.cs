using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Commands;
using Application.Features.CheckLists.Dtos.Validators;
using AutoMapper;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Handlers
{
    public class UpdateCheckListCommandHandler:IRequestHandler<UpdateCheckListCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCheckListCommandHandler(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;

            _mapper = Mapper;
        }
        public async Task<Unit> Handle(UpdateCheckListCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCheckListDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CheckListDto);

            if (!validationResult.IsValid) throw new ValidationException("Validation error",validationResult.Errors);

            var checkList = await _unitOfWork.CheckListRepository.GetByIdAsync(request.CheckListDto.Id);

            if (checkList == null) throw new NotFoundException("CheckList not found");

            _mapper.Map(request.CheckListDto, checkList);

            if (await _unitOfWork.Save() == 0) throw new AppException("Server error: couldn't save data");

            return Unit.Value;
        }
    }
}
