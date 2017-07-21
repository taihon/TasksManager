using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.Entities;
using Task = System.Threading.Tasks.Task;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class RemoveTagFromTask :  IRemoveTagFromTask
    {
        private TasksContext _context;
        public RemoveTagFromTask(TasksContext context)
        {
            _context = context;
        }
        public async Task ExecuteAsync(int taskId, string tag)
        {
            Entities.Task taskFoundInDb = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
            if (taskFoundInDb != null)
            {
                TagsInTask tagsInTask =
                    await _context.TagsInTask.Include("Tag").FirstOrDefaultAsync(t => t.Tag.Name == tag && t.TaskId == taskId);
                if (tagsInTask != null)
                {
                    _context.TagsInTask.Remove(tagsInTask);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
