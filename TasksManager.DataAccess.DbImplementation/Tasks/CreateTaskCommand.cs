using AutoMapper;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class CreateTaskCommand : ICreateTaskCommand
    {
        private TasksContext Context;
        private IMapper Mapper;
        public CreateTaskCommand(TasksContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public async Task<TaskResponse> ExecuteAsync(CreateTaskRequest request)
        {
            Entities.Task taskToCreate = Mapper.Map<CreateTaskRequest, Entities.Task>(request);
            await Context.Tasks.AddAsync(taskToCreate);
            await Context.SaveChangesAsync();
            return Mapper.Map<Entities.Task, TaskResponse>(taskToCreate);
        }
    }
}
