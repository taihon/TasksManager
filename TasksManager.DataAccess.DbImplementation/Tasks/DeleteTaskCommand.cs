using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class DeleteTaskCommand : IDeleteTaskCommand
    {
        public Task ExecuteAsync(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
