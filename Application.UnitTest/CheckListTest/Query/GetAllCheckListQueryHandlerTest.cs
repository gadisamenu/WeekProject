using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Handlers;
using Application.Features.CheckLists.CQRS.Queries;
using Application.Features.CheckLists.Dtos;
using Application.UnitTest.Mocks;
using AutoMapper;
using BlogApp.Application.Profiles;
using Moq;
using Shouldly;

namespace Application.UnitTest.CheckListTest.Query
{
    public class GetAllCheckListQueryHandlerTest
    {


        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetAllCheckListQueryHandler _handler;
        public GetAllCheckListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetAllCheckListQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetCheckListList()
        {
            var result = await _handler.Handle(new GetAllCheckListQuery(), CancellationToken.None);
            result.ShouldBeOfType<List<CheckListDto>>();
            result.Count().ShouldBe(2);
        }
    }
}



