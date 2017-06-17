using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Filters;
using TasksManager.ViewModels.Requests;
using TasksManager.ViewModels.Responses;

namespace TasksManager.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        //Get many
        [HttpGet]
        [ProducesResponseType(200, Type=typeof(ListResponse<TaskResponse>))]
        public Task<ListResponse<TaskResponse>> GetTasksListAsync(TaskFilter filter, ListOptions options)
        {
            throw new NotImplementedException();
        }

        //Create
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TaskResponse))]
        [ProducesResponseType(404)]
        public Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskRequest request)
        {
            throw new NotImplementedException();
        }

        //Read
        [HttpGet("{taskId}")]
        [ProducesResponseType(200, Type = typeof(TaskResponse))]
        [ProducesResponseType(404)]
        public Task<IActionResult> GetTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        //Update
        [HttpPut("{taskId}")]
        [ProducesResponseType(200, Type = typeof(TaskResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public Task<IActionResult> UpdateTaskAsync(int taskId, [FromBody] UpdateTaskRequest request)
        {
            throw new NotImplementedException();
        }
        //Delete
        [HttpDelete("{taskId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public Task<IActionResult> DeleteTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
