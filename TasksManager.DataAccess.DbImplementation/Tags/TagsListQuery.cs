using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Tags;
using TasksManager.Db;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tags;
using AutoMapper.QueryableExtensions;

namespace TasksManager.DataAccess.DbImplementation.Tags
{
    public class TagsListQuery : ITagsListQuery
    {
        private TasksContext _context;
        private IMapper _mapper;
        public TagsListQuery(TasksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ListResponse<TagResponse>> RunAsync(TagFilter filter, ListOptions options)
        {
            IQueryable<TagResponse> query = _context.Tags.ProjectTo<TagResponse>();
            query = ApplyFilter(query, filter);
            int totalCount = await query.CountAsync();
            if (options.Sort == null)
            {
                options.Sort = "Id";
            }
            query = options.ApplySort(query);
            query = options.ApplyPaging(query);
            //todo: refactor to use automapper
            return new ListResponse<TagResponse>
            {
                Items = await query.ToListAsync(),
                Sort = options.Sort ?? "-Id",
                Page = options.Page,
                PageSize = options.PageSize ?? -1,
                TotalItemsCount = totalCount
            };
        }

        private IQueryable<TagResponse> ApplyFilter(IQueryable<TagResponse> query, TagFilter filter)
        {
            if (filter.Name != null)
            {
                query = query.Where(t => t.Name.StartsWith(filter.Name));
            }
            return query;
        }
    }
}
