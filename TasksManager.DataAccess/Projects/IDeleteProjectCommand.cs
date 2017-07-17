using System.Threading.Tasks;

namespace TasksManager.DataAccess.Projects
{
    public interface IDeleteProjectCommand
    {
        /// <summary>
        /// <param name="projectId"></param>
        /// <exception cref="CannotDeleteProjectWithTasksException"></exception>
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task ExecuteAsync(int projectId);
    }
}
