using System.Threading.Tasks;
using AutoMapper;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModels.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class CreateProjectCommand : ICreateProjectCommand
    {
        private TasksContext _context;
        private IMapper _mapper;
        public CreateProjectCommand(TasksContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }
        public async Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request)
        {
            var project = _mapper.Map<CreateProjectRequest, Project>(request);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return _mapper.Map<Project, ProjectResponse>(project);
        }
    }
}
