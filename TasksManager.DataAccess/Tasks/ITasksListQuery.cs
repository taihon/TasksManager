using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.Tasks
{
    public interface ITasksListQuery
    {
        Task<ListResponse<TaskResponse>> RunAsync(TaskFilter filter, ListOptions options);
    }
}
