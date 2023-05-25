using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Handlers;
using Application.Features.CheckLists.CQRS.Queries;
using Application.Features.CheckLists.Dtos;
using Application.Profiles;
using Application.UnitTest.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.UnitTest.CheckListTest.Query;

public class GetCheckListDetailQueryHandlerTest
{


    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    private int Id;
    private readonly GetCheckListDetailQueryHandler _handler;
    public GetCheckListDetailQueryHandlerTest()
    {
        _mockRepo = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        Id = 1;

        _handler = new GetCheckListDetailQueryHandler(_mockRepo.Object, _mapper);

    }


    [Fact]
    public async Task GetCheckListDetail()
    {
        var result = await _handler.Handle(new GetCheckListDetailQuery() { Id = Id }, CancellationToken.None);
        result.ShouldBeOfType<CheckListDto>();
    }

    [Fact]
    public async Task GetNonExistingCheckList()
    {
        Id = 0;
        var result = await _handler.Handle(new GetCheckListDetailQuery() { Id = Id }, CancellationToken.None);
        result.ShouldBe(null);

    }
}