using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Commands;
using Application.Features.CheckLists.Dtos.Validators;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.CheckLists.CQRS.Handlers
{
    public class CreateCheckListCommandHandler : IRequestHandler<CreateCheckListCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCheckListCommandHandler(IUnitOfWork UnitOfWork,IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;

            _mapper = Mapper;
        }
        public async Task<int> Handle(CreateCheckListCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCheckListDtoValidator(_unitOfWork);

            var validationResult = await validator.ValidateAsync(request.CheckListDto);

            if (!validationResult.IsValid)  throw new ValidationException("Validation error",validationResult.Errors);

            var task = await _unitOfWork.TaskRepository.GetByIdAsync(request.CheckListDto.TaskId);
            
            var checkList = _mapper.Map<CheckList>(request.CheckListDto);
            checkList.Task = task;

            checkList = await _unitOfWork.CheckListRepository.AddAsync(checkList);
            if (await _unitOfWork.Save() == 0) throw new AppException("Server error: couldn't save data");

            return checkList.Id;
        }
    }
}
