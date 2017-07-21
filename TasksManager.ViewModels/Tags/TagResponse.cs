using System;
using System.Collections.Generic;
using System.Text;
using TasksManager.Entities;

namespace TasksManager.ViewModels.Tags
{
    public class TagResponse
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<TagsInTask> Tasks { get; set; }
        public int TotalTaskCount { get; set; }
        public int OpenTaskCount { get; set; }
    }
}