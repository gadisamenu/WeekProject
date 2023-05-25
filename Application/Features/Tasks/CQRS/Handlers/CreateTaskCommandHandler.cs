using Application.Common.Exceptions;
using Application.Contracts;
using Application.Contracts.Presistence;
using Application.Features.Tasks.CQRS.Commands;
using Application.Features.Tasks.Dtos.Validators;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Tasks.CQRS.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<User> _userManager;
        public CreateTaskCommandHandler(IUnitOfWork UnitOfWork,IMapper Mapper,IUserAccessor userAccessor)
        {
            _unitOfWork = UnitOfWork;
            _userAccessor = userAccessor;
            _mapper = Mapper;
        }
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTaskDtoValidator(_unitOfWork);

            var validationResult = await validator.ValidateAsync(request.TaskDto);

            if (!validationResult.IsValid)  throw new ValidationException("Validation error",validationResult.Errors);
          
            var Task = _mapper.Map<ETask>(request.TaskDto);

            var user = _unitOfWork.UserManager.Users.FirstOrDefault(u => u.UserName == _userAccessor.GetUsername());

            Task.Owner = user;

            Task = await _unitOfWork.TaskRepository.AddAsync(Task);
            if (await _unitOfWork.Save() == 0) throw  new AppException("Server error: couldn't save data");
            
            return Task.Id;
        }
    }
}
