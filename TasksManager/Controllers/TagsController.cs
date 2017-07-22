using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TasksManager.Entities;
using TasksManager.ViewModels;
using TasksManager.ViewModels.Tags;

namespace TasksManager.Controllers
{
    public class TagsController:Controller
    {
        [HttpGet]
        [ProducesResponseType(200, Type=typeof(ListResponse<TagResponse>))]
        public async Task<IActionResult> GetTagsListAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(201, Type =typeof(TagResponse))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTagAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{tagId}")]
        [ProducesResponseType(200, Type = typeof(TagResponse))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTagAsync(int tagId)
        {
            throw  new NotImplementedException();
        }

        [HttpGet("{tagId}", Name = "GetSingleTag")]
        [ProducesResponseType(200, Type = typeof(TagResponse))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetTagAsync(int tagId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{tagId}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTagAsync(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
