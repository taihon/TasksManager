using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private IMapper Mapper;
        public UpdateProjectCommand(TasksContext tasksContext, IMapper mappper)
        {
            Context = tasksContext;
            Mapper = mappper;
        }
        public async Task<ProjectResponse> ExecuteAsync(int projectId, UpdateProjectRequest request)
        {
            Project foundProject = await Context.Projects.FirstOrDefaultAsync(t => t.Id == projectId);
            if (foundProject != null)
            {
                Project mappedProject = Mapper.Map<UpdateProjectRequest, Project>(request);
                mappedProject.Id = projectId;
                Context.Entry(foundProject).CurrentValues.SetValues(mappedProject);
                await Context.SaveChangesAsync();
            }
            return Mapper.Map<Project,ProjectResponse>(foundProject);
        }
    }
}
