using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.DataAccess.Queries;
using TasksManager.DB;
using TasksManager.ViewModels.Responses;
using TasksManager.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TasksManager.DataAccess.DbImplementation.Queries
{
    public class ProjectQuery : IProjectQuery
    {
        private TasksContext context { get; }
        public ProjectQuery(TasksContext tasksContext) {
            context = tasksContext;
        }

        public async Task<ProjectResponse> RunAsync(int projectId)
        {
            ProjectResponse response = await context.Projects
                .Select(p => new ProjectResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
                }).FirstOrDefaultAsync(p => p.Id == projectId);
            return response;
        }
    }
}
