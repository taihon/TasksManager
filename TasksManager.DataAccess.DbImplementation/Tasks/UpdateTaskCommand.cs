using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class UpdateTaskCommand : IUpdateTaskCommand
    {
        public Task<TaskResponse> ExecuteAsync(int taskId, UpdateTaskRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
