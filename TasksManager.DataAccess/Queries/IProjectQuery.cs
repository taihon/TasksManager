using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels.Responses;

namespace TasksManager.DataAccess.Queries
{
    public interface IProjectQuery
    {
        Task<ProjectResponse> RunAsync(int projectId);
    }
}
