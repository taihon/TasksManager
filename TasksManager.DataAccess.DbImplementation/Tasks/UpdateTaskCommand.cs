using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.ViewModels.Tasks;
using TaskStatus = TasksManager.Entities.TaskStatus;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class UpdateTaskCommand : IUpdateTaskCommand
    {
        private TasksContext _context;
        private IMapper _mapper;
        public UpdateTaskCommand(TasksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TaskResponse> ExecuteAsync(int taskId, UpdateTaskRequest request)
        {
            Entities.Task foundTask = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
            if (foundTask != null)
            {
                Entities.Task mappedTask = _mapper.Map<UpdateTaskRequest, Entities.Task>(request);
                if (mappedTask.Status == TaskStatus.Completed)
                {
                    mappedTask.CompleteDate = DateTime.Now;
                }
                mappedTask.Id = taskId;
                foundTask = _mapper.Map(mappedTask,foundTask);
                await _context.SaveChangesAsync();
            }
            return _mapper.Map<Entities.Task,TaskResponse>(foundTask);
        }
    }
}
