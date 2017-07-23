using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.ViewModels.Projects;
using AutoMapper.QueryableExtensions;

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
            ProjectResponse response = Context.Projects
                .ProjectTo<ProjectResponse>()
                .FirstOrDefault(p => p.Id == projectId);
            return response;
        }
    }
}
