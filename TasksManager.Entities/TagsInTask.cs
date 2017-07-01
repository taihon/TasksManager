using System;
using System.Collections.Generic;
using System.Text;

namespace TasksManager.Entities
{
    public class TagsInTask:DomainObject
    {
        public Task Task { get; set; }
        public int TaskId { get; set; }

        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
