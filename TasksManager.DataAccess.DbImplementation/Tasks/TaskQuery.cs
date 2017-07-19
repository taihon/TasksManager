using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class TaskQuery : ITaskQuery
    {
        public Task<TaskResponse> RunAsync(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
