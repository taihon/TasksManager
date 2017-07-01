using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.DataAccess.Commands;
using TasksManager.DB;
using TasksManager.Entities;
using TasksManager.ViewModels.Requests;
using TasksManager.ViewModels.Responses;

namespace TasksManager.DataAccess.DbImplementation.Commands
{
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private TasksContext context { get; }
        public CreateProjectCommand(TasksContext tasksContext)
        {
            context = tasksContext;
        }
        public async Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description
            };
            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();
            return new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                OpenTasksCount = 0
            };
        }
    }
}
