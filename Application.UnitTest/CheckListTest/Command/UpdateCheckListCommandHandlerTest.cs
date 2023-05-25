using Application.Common.Exceptions;
using Application.Contracts.Presistence;
using Application.Features.CheckLists.CQRS.Commands;
using Application.Features.CheckLists.CQRS.Handlers;
using Application.Features.CheckLists.Dtos;
using Application.Profiles;
using Application.UnitTest.Mocks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;

namespace Application.UnitTest.CheckListTest.Command;

public class UpdateCheckListCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockRepo;
    private readonly UpdateCheckListDto _checkListDto;
    private readonly UpdateCheckListCommandHandler _handler;
    public UpdateCheckListCommandHandlerTest()
    {
        _mockRepo = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _checkListDto = new UpdateCheckListDto
        {
            Id = 1,
            Title = "newTitle",
            Description = "description",
        };

        _handler = new UpdateCheckListCommandHandler(_mockRepo.Object, _mapper);

    }


    [Fact]
    public async Task UpdateCheckList()
    {
        var result = await _handler.Handle(new UpdateCheckListCommand() { CheckListDto = _checkListDto }, CancellationToken.None);
        result.ShouldBeOfType<Unit>();

        var checkList = await _mockRepo.Object.CheckListRepository.GetByIdAsync(_checkListDto.Id);
        checkList.Title.Equals(_checkListDto.Title);
        checkList.Description.Equals(_checkListDto.Description);
    }

    [Fact]
    public async Task Update_With_Invalid_CheckListNO()
    {
        _checkListDto.Id = -1;
        await Should.ThrowAsync<ValidationException>
          (async () => await _handler.Handle(new UpdateCheckListCommand() { CheckListDto = _checkListDto }, CancellationToken.None));


    }


}



