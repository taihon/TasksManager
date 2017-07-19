using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class TasksListQuery : ITasksListQuery
    {
        public Task<ListResponse<TaskResponse>> RunAsync(TaskFilter filter, ListOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
