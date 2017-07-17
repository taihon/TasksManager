using System.Threading.Tasks;
using TasksManager.ViewModels.Projects;

namespace TasksManager.DataAccess.Projects
{
    public interface IProjectQuery
    {
        Task<ProjectResponse> RunAsync(int projectId);
    }
}
