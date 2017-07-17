using System.Threading.Tasks;
using TasksManager.ViewModels.Projects;

namespace TasksManager.DataAccess.Projects
{
    public interface ICreateProjectCommand
    {
        Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request);
    }
}
