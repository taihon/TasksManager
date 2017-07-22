using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tags;

namespace TasksManager.DataAccess.Tags
{
    public interface ITagsListQuery
    {
        Task<ListResponse<TagResponse>> RunAsync(TagFilter filter, ListOptions options);
    }
}
