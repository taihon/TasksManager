using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class DeleteTaskCommand : IDeleteTaskCommand
    {
        private TasksContext _context;
        private IMapper _mapper;
        public DeleteTaskCommand(TasksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(int taskId)
        {
            Entities.Task taskToDelete = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
