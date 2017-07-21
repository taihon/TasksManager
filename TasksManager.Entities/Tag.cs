using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace TasksManager.Entities
{
    public class Tag:DomainObject
    {
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }
        public ICollection<TagsInTask> Tasks { get; set; }
        [NotMapped]
        public int OpenTaskCount { get { return Tasks?.Count(t => t.Task.Status != TaskStatus.Completed)??0; } }
        [NotMapped]
        // ReSharper disable once ArrangeAccessorOwnerBody
        public int TotalTaskCount { get { return Tasks?.Count ?? 0; }}
    }
}
