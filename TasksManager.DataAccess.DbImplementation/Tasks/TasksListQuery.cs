using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tasks;

namespace TasksManager.DataAccess.DbImplementation.Tasks
{
    public class TasksListQuery : ITasksListQuery
    {
        private TasksContext _context;
        private IMapper _mapper;
        public TasksListQuery(TasksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private IQueryable<TaskResponse> ApplyFilter(IQueryable<TaskResponse> query, TaskFilter filter)
        {
            if (filter.Name != null)
            {
                query = query.Where(t => t.Name.StartsWith(filter.Name));
            }
            if (filter.DueDate != null)
            {
                if (filter.DueDate.From != null)
                {
                    query = query.Where(t => t.DueDate >= filter.DueDate.From);
                }
                if (filter.DueDate.To != null)
                {
                    query = query.Where(t => t.DueDate <= filter.DueDate.To);
                }
            }
            if (filter.CreateDate != null)
            {
                if (filter.CreateDate.From != null)
                {
                    query = query.Where(t => t.CreateDate >= filter.CreateDate.From);
                }
                if (filter.CreateDate.To != null)
                {
                    query = query.Where(t => t.CreateDate <= filter.CreateDate.To);
                }
            }
            if (filter.CompleteDate != null)
            {
                if (filter.CompleteDate.From != null)
                {
                    query = query.Where(t => t.CompleteDate >= filter.CompleteDate.From);
                }
                if (filter.CompleteDate.To != null)
                {
                    query = query.Where(t => t.CompleteDate <= filter.CompleteDate.To);
                }
            }
            if (filter.Status != null)
            {
                query = query.Where(t => t.Status == filter.Status);
            }
            if (filter.ProjectId != null)
            {
                query = query.Where(t => t.ProjectId == filter.ProjectId);
            }
            if (filter.Tag != null)
            {
                query = query.Where(t => t.Tags.Contains(filter.Tag));
            }
            if (filter.HasDueDate != null)
            {
                query = query.Where(t => t.DueDate != null);
            }
            return query;
        }
        public async Task<ListResponse<TaskResponse>> RunAsync(TaskFilter filter, ListOptions options)
        {
            IQueryable<TaskResponse> query = _context.Tasks.ProjectTo<TaskResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<TaskResponse>
            {
                Items = await query.ToListAsync(),
                Sort = options.Sort,
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                TotalItemsCount = totalCount
            };
        }
    }
}

