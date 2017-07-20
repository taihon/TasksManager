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
        private TasksContext _context;
        private IMapper _mapper;
        public UpdateProjectCommand(TasksContext tasksContext, IMapper mappper)
        {
            _context = tasksContext;
            _mapper = mappper;
        }
        public async Task<ProjectResponse> ExecuteAsync(int projectId, UpdateProjectRequest request)
        {
            Project foundProject = await _context.Projects.FirstOrDefaultAsync(t => t.Id == projectId);
            if (foundProject != null)
            {
                Project mappedProject = _mapper.Map<UpdateProjectRequest, Project>(request);
                mappedProject.Id = projectId;
                _context.Entry(foundProject).CurrentValues.SetValues(mappedProject);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Project,ProjectResponse>(foundProject);
        }
    }
}
