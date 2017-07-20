using AutoMapper;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class CreateTaskCommand : ICreateTaskCommand
    {
        private TasksContext _context;
        private IMapper _mapper;
        public CreateTaskCommand(TasksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<TaskResponse> ExecuteAsync(CreateTaskRequest request)
        {
            Entities.Task taskToCreate = _mapper.Map<CreateTaskRequest, Entities.Task>(request);
            await _context.Tasks.AddAsync(taskToCreate);
            await _context.SaveChangesAsync();
            return _mapper.Map<Entities.Task, TaskResponse>(taskToCreate);
        }
    }
}
