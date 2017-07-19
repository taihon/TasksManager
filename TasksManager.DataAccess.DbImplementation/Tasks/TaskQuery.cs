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
        private IMapper Mapper;
        private TasksContext Context;
        public TaskQuery(TasksContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }
        public async Task<TaskResponse> RunAsync(int taskId)
        {
            Entities.Task response = await Context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);

            return Mapper.Map<Entities.Task, TaskResponse>(response);

        }
    }
}
