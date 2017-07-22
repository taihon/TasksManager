using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksManager.DataAccess.Tags;
using TasksManager.Entities;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tags;

namespace TasksManager.Controllers
{
    [Route("api/[controller]")]
    public class TagsController:Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type=typeof(ListResponse<TagResponse>))]
        public async Task<IActionResult> GetTagsListAsync(TagFilter filter, ListOptions options,[FromServices]ITagsListQuery query)
        {
            ListResponse<TagResponse> response = await query.RunAsync(filter, options);
            return Ok(response);
        }

        [HttpDelete("{tagId}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTagAsync(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
