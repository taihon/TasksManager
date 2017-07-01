using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TasksManager.DataAccess.Commands;
using TasksManager.DataAccess.Queries;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Filters;
using TasksManager.ViewModels.Requests;
using TasksManager.ViewModels.Responses;

namespace TasksManager.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ListResponse<ProjectResponse>))]
        public async Task<IActionResult> GetProjectsListAsync(ProjectFilter project, ListOptions options, [FromServices]IProjectsListQuery query)
        {
            var response = await query.RunAsync(project, options);
            return Ok(response);
        }



        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProjectResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateProjectAsync([FromBody] CreateProjectRequest project, [FromServices]ICreateProjectCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ProjectResponse response = await command.ExecuteAsync(project);
            return Ok(response);
        }

        [HttpGet("{projectId}")]
        [ProducesResponseType(200, Type = typeof(ProjectResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetProjectAsync(int projectId, [FromServices] IProjectQuery query)
        {
            ProjectResponse response = await query.RunAsync(projectId);
            return response == null ? (IActionResult)NotFound() : Ok(response);
        }

        [HttpPut("{projectId}")]
        [ProducesResponseType(200, Type=typeof(ProjectResponse))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public Task<IActionResult> UpdateProjectAsync(int projectId, [FromBody] UpdateProjectRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{projectId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public Task<IActionResult> DeleteProjectAsync(int projectId)
        {
            throw new NotImplementedException();
        }
    }
}
