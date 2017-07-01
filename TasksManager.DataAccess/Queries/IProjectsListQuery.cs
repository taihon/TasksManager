using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Filters;
using TasksManager.ViewModels.Responses;

namespace TasksManager.DataAccess.Queries
{
    public interface IProjectsListQuery
    {
        Task<ListResponse<ProjectResponse> RunAsync(ProjectFilter filter, ListOptions options);
    }
}
