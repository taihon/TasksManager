using System;
using TasksManager.ViewModels.Projects;

namespace TasksManager.ViewModels.Tasks
{
    public class TaskResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string[] Tags { get; set; }

        public int ProjectId { get; set; }

        public ProjectResponse Project { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public TaskStatus Status { get; set; }
    }
}
