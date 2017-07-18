using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.Entities;
using Task = System.Threading.Tasks.Task;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class DeleteProjectCommand : IDeleteProjectCommand
    {
        private TasksContext Context;

        public DeleteProjectCommand(TasksContext context)
        {
            Context = context;
        }
        public async Task ExecuteAsync(int projectId)
        {
            Project projectToDelete = Context.Projects.FirstOrDefault(p => p.Id == projectId);
            if (projectToDelete?.Tasks?.Count > 0)
            {
                throw new CannotDeleteProjectWithTasksException();
            }
            if (projectToDelete != null)
            {
                Context.Projects.Remove(projectToDelete);
                await Context.SaveChangesAsync();
            }
        }
    }
}
