﻿using Application.Features.Tasks.CQRS.Commands;
using Application.Features.Tasks.CQRS.Queries;
using Application.Features.Tasks.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TasksController : BasaApiController
    {
        [HttpGet] //api/Tasks
        public async Task<IActionResult> GetTask()
        {
            return Ok(await Mediator.Send(new GetAllTaskQuery()));
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTask(int Id)
        {
            return Ok(await Mediator.Send(new GetTaskDetailQuery { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto Task)
        {
            return Ok(await Mediator.Send(new CreateTaskCommand { TaskDto = Task }));
        }

        [Authorize(Policy = "IsTaskOwner")]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto Task)
        {
            return Ok(await Mediator.Send(new UpdateTaskCommand { TaskDto = Task }));
        }

        [Authorize(Policy = "IsTaskOwner")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteActvity(int Id)
        {
            return Ok(await Mediator.Send(new DeleteTaskCommand { Id = Id }));
        }
    }
}