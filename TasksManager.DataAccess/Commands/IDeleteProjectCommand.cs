using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TasksManager.DataAccess.Commands
{
    public interface IDeleteProjectCommand
    {
        Task ExecuteAsync(int projectId);
    }
}
