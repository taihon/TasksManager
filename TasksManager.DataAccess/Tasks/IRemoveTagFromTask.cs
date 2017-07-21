using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TasksManager.DataAccess.Tasks
{
    public interface IRemoveTagFromTask
    {
        Task ExecuteAsync(int taskId, string tag);
    }
}
