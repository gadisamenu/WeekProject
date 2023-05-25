using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using Application.UnitTest.Mocks;
using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Handlers;
using Application.Features.CheckLists.CQRS.Commands;
using Application.Common.Exceptions;
using Application.Profiles;

namespace Application.UnitTest.CheckListTest.Command
{
    public class DeleteCheckListCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteCheckListCommandHandler _handler;
  
        public DeleteCheckListCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _id = 2;

            _handler = new DeleteCheckListCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task DeleteCheckList()
        {

            var result = await _handler.Handle(new DeleteCheckListCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Unit>();

            var CheckLists = await _mockRepo.Object.CheckListRepository.GetAllAsync();
            CheckLists.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_CheckList_Doesnt_Exist()
        {

            _id = 0;
            await Should.ThrowAsync<NotFoundException>
              (async () => await _handler.Handle(new DeleteCheckListCommand() { Id = _id }, CancellationToken.None));

            var CheckLists = await _mockRepo.Object.CheckListRepository.GetAllAsync();
            CheckLists.Count().ShouldBe(2);

        }
    }
}



