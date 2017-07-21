using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.Tasks
{
    public interface IAddTagToTaskCommand
    {
        Task<TaskResponse> ExecuteAsync(int taskId, string tag);
    }
}
