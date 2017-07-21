using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class TaskQuery : ITaskQuery
    {
        private IMapper _mapper;
        private TasksContext _context;
        public TaskQuery(TasksContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<TaskResponse> RunAsync(int taskId)
        {
            Entities.Task response = await _context.Tasks
                .Include(t=>t.Tags)
                .ThenInclude(t=>t.Tag)
                .FirstOrDefaultAsync(t => t.Id == taskId);

            return _mapper.Map<Entities.Task, TaskResponse>(response);

        }
    }
}
