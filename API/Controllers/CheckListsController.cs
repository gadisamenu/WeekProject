using Application.Features.CheckLists.CQRS.Commands;
using Application.Features.CheckLists.CQRS.Queries;
using Application.Features.CheckLists.Dtos;
using Application.Features.Tasks.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /* [ApiController]
     [Authorize(Policy ="IsTa")]
     [Route("api/tasks/{taskId}/[controller]")]*/
    public class CheckListsController : BasaApiController
    {
        [Authorize(Policy = "IsCheckListTaskOwner")]
        [HttpGet] //api/CheckLists
        public async Task<IActionResult> GetCheckList()
        {
            return Ok(await Mediator.Send(new GetAllCheckListQuery()));
        }

      /*  [Authorize(Policy = "IsCheckListTaskOwner")]*/
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCheckList(int Id)
        {
            return Ok(await Mediator.Send(new GetCheckListDetailQuery { Id = Id }));
        }

        [Authorize(Policy = "IsCheckListTaskOwner")]
        [HttpPost]
        public async Task<IActionResult> CreateCheckList(CreateCheckListDto CheckList)
        {
            return Ok(await Mediator.Send(new CreateCheckListCommand { CheckListDto = CheckList }));
        }

        [Authorize(Policy = "IsCheckListOwner")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCheckList(UpdateCheckListDto CheckList)
        {
            return Ok(await Mediator.Send(new UpdateCheckListCommand { CheckListDto = CheckList }));
        }

        [Authorize(Policy = "IsCheckListOwner")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActvity(int Id)
        {
            return Ok(await Mediator.Send(new DeleteCheckListCommand { Id = Id }));
        }
    }
}