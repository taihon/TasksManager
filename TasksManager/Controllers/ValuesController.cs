using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TasksManager.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        static List<string> values = new List<string>();
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return values;
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            var postedValue = $"{values.Count}-value";
            values.Add(postedValue);
            return postedValue;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            string foundValue = values.FirstOrDefault(t => t.StartsWith($"{id}-"));
            if (foundValue == null)
                return NotFound();
            return Ok(foundValue);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            string searchValue = $"{id}-{value}";
            int idx = values.IndexOf(searchValue);
            if (idx == -1)
                return NotFound();
            values[idx] = searchValue;
            return Ok(searchValue);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string foundValue = values.FirstOrDefault(t => t.StartsWith($"{id}-"));
            if (foundValue != null)
                values.Remove(foundValue);
        }
    }
}
