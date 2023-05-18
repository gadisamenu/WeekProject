using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.Tasks.CQRS.Commands;
using Application.Features.Tasks.CQRS.Handlers;
using Application.Features.Tasks.Dtos;
using Application.UnitTest.Mocks;
using AutoMapper;
using BlogApp.Application.Profiles;
using Moq;
using Shouldly;

namespace Application.UnitTest.Ratetest.Command
{
    public class CreateTaskCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateTaskDto _taskDto;
        private readonly CreateTaskCommandHandler _handler;

        public CreateTaskCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _taskDto = new CreateTaskDto
            {
                Completed = false,
                StartDate = "20/2/2023",
                EndDate = "21/2/2023",
                Description = "description",
            };

            _handler = new CreateTaskCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateTask()
        {
            var result = await _handler.Handle(new CreateTaskCommand() { TaskDto = _taskDto }, CancellationToken.None);
            result.ShouldBeOfType<int>();
  
            var tasks = await _mockRepo.Object.TaskRepository.GetAllAsync();
            tasks.Count().ShouldBe(3);

        }

        [Fact]
        public async Task InvalidTask_Added()
        {

            _taskDto.StartDate = "22/2/2023";

            await Should.ThrowAsync<ValidationException>
               ( async () =>  await _handler.Handle(new CreateTaskCommand() { TaskDto = _taskDto }, CancellationToken.None) );

            var tasks = await _mockRepo.Object.TaskRepository.GetAllAsync();
            tasks.Count().ShouldBe(2);

        }
    }
}




