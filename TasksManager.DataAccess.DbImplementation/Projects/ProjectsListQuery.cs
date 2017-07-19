using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Projects;
using TasksManager.Db;
using TasksManager.Entities;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Projects;
using AutoMapper.QueryableExtensions;

namespace TasksManager.DataAccess.DbImplementation.Projects
{
    public class ProjectsListQuery:IProjectsListQuery
    {
        private TasksContext _context;
        private IMapper _mapper;
        public ProjectsListQuery(TasksContext tasksContext, IMapper mapper)
        {
            _context = tasksContext;
            _mapper = mapper;
        }

        private IQueryable<ProjectResponse> ApplyFilter(IQueryable<ProjectResponse> query, ProjectFilter filter)
        {
            if (filter.Id != null)
            {
                query = query.Where(p => p.Id == filter.Id);
            }

            if (filter.Name != null)
            {
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            }

            if (filter.OpenTasksCount != null)
            {
                if (filter.OpenTasksCount.From != null)
                {
                    query = query.Where(p => p.OpenTasksCount >= filter.OpenTasksCount.From);
                }

                if (filter.OpenTasksCount.To != null)
                {
                    query = query.Where(p => p.OpenTasksCount <= filter.OpenTasksCount.To);
                }
            }
            return query;
        }

        public async Task<ListResponse<ProjectResponse>> RunAsync(ProjectFilter filter, ListOptions options)
        {
            IQueryable<ProjectResponse> query = _context.Projects.Include("Tasks")
                .ProjectTo<ProjectResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }

            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            return new ListResponse<ProjectResponse>
            {
                Items = await query.ToListAsync(),
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                Sort = options.Sort ?? "-Id",
                TotalItemsCount = totalCount
            };
        }
    }
}
