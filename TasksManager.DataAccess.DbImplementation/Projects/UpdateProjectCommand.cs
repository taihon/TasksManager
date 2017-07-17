using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModels.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class UpdateProjectCommand:IUpdateProjectCommand
    {
        private TasksContext Context;
        public UpdateProjectCommand(TasksContext tasksContext)
        {
            Context = tasksContext;
        }
        public async Task<ProjectResponse> ExecuteAsync(int projectId, UpdateProjectRequest request)
        {
            Project foundProject = await Context.Projects.FirstOrDefaultAsync(t => t.Id == projectId);
            if (foundProject != null)
            {
                
            }
            return new ProjectResponse();
        }
    }
}
