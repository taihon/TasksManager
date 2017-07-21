using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        //Get many
        [HttpGet]
        [ProducesResponseType(200, Type=typeof(ListResponse<TaskResponse>))]
        public async Task<IActionResult> GetTasksListAsync(TaskFilter filter, ListOptions options, [FromServices]ITasksListQuery query)
        {
            ListResponse<TaskResponse> response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        //Create
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TaskResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskRequest request, [FromServices]ICreateTaskCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            TaskResponse createdTask = await command.ExecuteAsync(request);
            return CreatedAtRoute("GetSingleTask", new {taskId = createdTask.Id}, createdTask);
        }

        //Read
        [HttpGet("{taskId}", Name = "GetSingleTask")]
        [ProducesResponseType(200, Type = typeof(TaskResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTaskAsync(int taskId, [FromServices]ITaskQuery query)
        {
            TaskResponse response = await query.RunAsync(taskId);
            return response == null ? (IActionResult) NotFound($"Task with id {taskId} not found") : Ok(response);
        }

        //Update
        [HttpPut("{taskId}")]
        [ProducesResponseType(200, Type = typeof(TaskResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTaskAsync(int taskId, [FromBody] UpdateTaskRequest request, [FromServices]IUpdateTaskCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TaskResponse response = await command.ExecuteAsync(taskId, request);
            return response == null ? (IActionResult) NotFound($"Task with id {taskId} not found") : Ok(response);
        }
        //Delete
        [HttpDelete("{taskId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteTaskAsync(int taskId, [FromServices]IDeleteTaskCommand command)
        {
            await command.ExecuteAsync(taskId);
            return NoContent();
        }
        //Add tag to task
        [HttpPut("{taskId}/tags/{tag}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddTagAsync(int taskId, string tag,[FromServices]IAddTagToTaskCommand command)
        {
            TaskResponse response = await command.ExecuteAsync(taskId, tag);
            return response == null?(IActionResult)NotFound($"Task with id {taskId} not found"):Ok(response);
        }

    }
}
