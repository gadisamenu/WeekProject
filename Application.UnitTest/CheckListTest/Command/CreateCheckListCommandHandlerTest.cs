using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Commands;
using Application.Features.CheckLists.CQRS.Handlers;
using Application.Features.CheckLists.Dtos;
using Application.Profiles;
using Application.UnitTest.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.UnitTest.CheckListTest.Command
{
    public class CreateCheckListCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateCheckListDto _CheckListDto;
        private readonly CreateCheckListCommandHandler _handler;

        public CreateCheckListCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _CheckListDto = new CreateCheckListDto
            {
                Completed = false,
                TaskId =  1,
                Title = "the Title",
                Description = "description",
            };

            _handler = new CreateCheckListCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateCheckList()
        {
            var result = await _handler.Handle(new CreateCheckListCommand() { CheckListDto = _CheckListDto }, CancellationToken.None);
            result.ShouldBeOfType<int>();

            var CheckLists = await _mockRepo.Object.CheckListRepository.GetAllAsync();
            CheckLists.Count().ShouldBe(3);

        }

        [Fact]
        public async Task InvalidCheckList_Added()
        {

            _CheckListDto.TaskId = 0;

            await Should.ThrowAsync<ValidationException>
               (async () => await _handler.Handle(new CreateCheckListCommand() { CheckListDto = _CheckListDto }, CancellationToken.None));

            var CheckLists = await _mockRepo.Object.CheckListRepository.GetAllAsync();
            CheckLists.Count().ShouldBe(2);

        }
    }
}




