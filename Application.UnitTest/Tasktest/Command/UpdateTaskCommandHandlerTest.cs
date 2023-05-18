using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.Tasks.CQRS.Commands;
using Application.Features.Tasks.CQRS.Handlers;
using Application.Features.Tasks.Dtos;
using Application.UnitTest.Mocks;
using AutoMapper;
using BlogApp.Application.Profiles;
using MediatR;
using Moq;
using Shouldly;

namespace Application.UnitTest.Tasktest.Command
{
    public class UpdateTaskCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly UpdateTaskDto _taskDto;
        private readonly UpdateTaskCommandHandler _handler;
        public UpdateTaskCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _taskDto = new UpdateTaskDto
            {
                Id = 1,
                StartDate = "20/2/2023",
                EndDate = "21/2/2023",
                Description = "description",
            };

            _handler = new UpdateTaskCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task UpdateTask()
        {
            var result = await _handler.Handle(new UpdateTaskCommand() { TaskDto = _taskDto }, CancellationToken.None);
            result.ShouldBeOfType<Unit>();

            var Task = await _mockRepo.Object.TaskRepository.GetByIdAsync(_taskDto.Id);
            Task.Id.Equals(_taskDto.Id);
            Task.EndDate.Equals(_taskDto.EndDate);
            Task.StartDate.Equals(_taskDto.StartDate);
            Task.Description.Equals(_taskDto.Description);
        }

        [Fact]
        public async Task Update_With_Invalid_TaskNO()
        {
            _taskDto.Id = -1;
            await Should.ThrowAsync<ValidationException>
              (async () => await _handler.Handle(new UpdateTaskCommand() { TaskDto = _taskDto }, CancellationToken.None));


        }


    }
}



