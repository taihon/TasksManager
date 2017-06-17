using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        [ProducesResponseType(200, Type=typeof(ListResponse<ProjectResponse>))]
        public Task<List<ProjectResponse>> GetProjectsListAsync(ProjectFilter project, ListOptions options)
        {
            throw new NotImplementedException();
        }



        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProjectResponse))]
        [ProducesResponseType(404)]
        public Task<IActionResult> CreateProjectAsync([FromBody] CreateProjectRequest project)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{projectId}")]
        [ProducesResponseType(200, Type = typeof(ProjectResponse))]
        [ProducesResponseType(404)]
        public Task<IActionResult> GetProjectAsync(int projectId)
        {
            throw new NotImplementedException();
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
