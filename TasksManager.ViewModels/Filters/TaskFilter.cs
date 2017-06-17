using System;

namespace TasksManager.ViewModels.Filters
{
    public class TaskFilter
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreateDateFrom { get; set; }

        public DateTime? CreateDateTo { get; set; }

        public DateTime? CompleteDateFrom { get; set; }

        public DateTime? CompleteDateTo { get; set; }

        public DateTime? DueDateFrom { get; set; }

        public DateTime? DueDateTo { get; set; }

        public TaskStatus? Status { get; set; }

        public int? ProjectId { get; set; }

        public string Tag { get; set; }
    }
}
