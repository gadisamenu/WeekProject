using Application.Features.Tasks.CQRS.Commands;
using Application.Features.Tasks.CQRS.Queries;
using Application.Features.Tasks.Dtos;
using Application.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TasksController : BasaApiController
    {
        [HttpGet] //api/Tasks
        public async Task<IActionResult> GetTask()
        {
            return HandleResult(CommonResponse<List<TaskDto>>.Successful(await Mediator.Send(new GetAllTaskQuery())));
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTask(int Id)
        {
            return HandleResult(CommonResponse<DetailedTaskDto>.Successful(await Mediator.Send(new GetTaskDetailQuery { Id = Id })));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto Task)
        {
            return  HandleResult(CommonResponse<int>.Successful(await Mediator.Send(new CreateTaskCommand { TaskDto = Task })));
        }

        [Authorize(Policy = "IsTaskOwner")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto Task)
        {
            return  HandleResult(CommonResponse<Unit>.Successful(await Mediator.Send(new UpdateTaskCommand { TaskDto = Task })));
        }

        [Authorize(Policy = "IsTaskOwner")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActvity(int Id)
        {
            return  HandleResult(CommonResponse<Unit>.Successful(await Mediator.Send(new DeleteTaskCommand { Id = Id })));
        }
    }
}