using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManager.DataAccess.Queries;
using TasksManager.DB;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Filters;
using TasksManager.ViewModels.Responses;

namespace TasksManager.DataAccess.DbImplementation.Queries
{
    public class ProjectsListQuery:IProjectsListQuery
    {
        private TasksContext context { get; }
        public ProjectsListQuery(TasksContext tasksContext)
        {
            context = tasksContext;
        }

        private IQueryable<ProjectResponse> ApplyFilter(IQueryable<ProjectResponse> query, ProjectFilter filter)
        {
            if (filter.Id != null)
                query = query.Where(p => p.Id == filter.Id);
            if (filter.Name != null)
                query = query.Where(p => p.Name.StartsWith(filter.Name));
            if (filter.OpenTasksCountTo != null)
                query = query.Where(p => p.OpenTasksCount <= filter.OpenTasksCountTo);
            return query;
        }

        public async Task<ListResponse<ProjectResponse>> RunAsync(ProjectFilter filter, ListOptions options)
        {
            IQueryable<ProjectResponse> query = context.Projects
                .Select(p=>new ProjectResponse
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        OpenTasksCount = p.Tasks.Count(t => t.Status != Entities.TaskStatus.Completed)
                    }
                );
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            query = options.ApplySort(query, "-Id");
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
