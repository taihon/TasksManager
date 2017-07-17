using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManager.DataAccess.Projects
{
    public class CannotDeleteProjectWithTasksException:Exception
    {
        public CannotDeleteProjectWithTasksException()
            : base("Project cannot be deleted, if there are tasks in it.") { }
    }
}
