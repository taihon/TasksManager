using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModels.Tasks;


namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class AddTagToTaskCommand : IAddTagToTaskCommand
    {
        private TasksContext _context;
        private IMapper _mapper;
        public AddTagToTaskCommand(TasksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TaskResponse> ExecuteAsync(int taskId, string tag)
        {
            Entities.Task taskInDb = await _context.Tasks.Include(t => t.Tags)
                .ThenInclude(t => t.Tag)
                .FirstOrDefaultAsync(task => task.Id == taskId);
            if (taskInDb != null)
            {
                if (taskInDb.Tags != null && taskInDb.Tags.All(t => t.Tag.Name != tag))
                {
                    TagsInTask tagToCreate = _mapper.Map<String, TagsInTask>(tag);
                    tagToCreate.Task = taskInDb;
                    taskInDb.Tags.Add(tagToCreate);
                    await _context.SaveChangesAsync();
                }
            }
            return _mapper.Map<Entities.Task, TaskResponse>(taskInDb);
        }
        
    }
}
