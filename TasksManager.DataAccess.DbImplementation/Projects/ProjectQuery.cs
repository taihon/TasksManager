using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.ViewModels.Projects;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class ProjectQuery : IProjectQuery
    {
        private TasksContext Context { get; }
        public ProjectQuery(TasksContext tasksContext) {
            Context = tasksContext;
        }

        public async Task<ProjectResponse> RunAsync(int projectId)
        {
            ProjectResponse response = await Context.Projects
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
