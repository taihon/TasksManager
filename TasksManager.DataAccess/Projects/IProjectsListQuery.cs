using System.Threading.Tasks;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Projects;

namespace TasksManager.DataAccess.Projects
{
    public interface IProjectsListQuery
    {
        Task<ListResponse<ProjectResponse>> RunAsync(ProjectFilter filter, ListOptions options);
    }
}
