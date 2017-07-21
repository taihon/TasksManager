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
            if (taskInDb != null && taskInDb.Tags.All(t=>t.Tag.Name!=tag))
            {
                Tag newTag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tag);
                if (newTag == null)
                {
                    //такого тега нет в системе, создадим
                    newTag = new Tag {Name = tag};
                    await _context.Tags.AddAsync(newTag);
                }
                TagsInTask tit = new TagsInTask
                {
                    Task = taskInDb,
                    Tag = newTag
                };
                await _context.TagsInTask.AddAsync(tit);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Entities.Task, TaskResponse>(taskInDb);
        }
        
    }
}
