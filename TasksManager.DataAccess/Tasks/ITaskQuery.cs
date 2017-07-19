using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.Tasks
{
    public interface ITaskQuery
    {
        Task<TaskResponse> RunAsync(int taskId);
    }
}
