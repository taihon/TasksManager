using System.Threading.Tasks;
using TasksManager.ViewModels.Projects;

namespace TasksManager.DataAccess.Projects
{
    public interface IUpdateProjectCommand
    {
        Task<ProjectResponse> ExecuteAsync(int projectId, UpdateProjectRequest request);
    }
}
