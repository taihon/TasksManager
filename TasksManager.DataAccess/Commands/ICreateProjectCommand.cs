using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels.Requests;
using TasksManager.ViewModels.Responses;

namespace TasksManager.DataAccess.Commands
{
    public interface ICreateProjectCommand
    {
        Task<ProjectResponse> ExecuteAsync(CreateProjectRequest request);
    }
}
