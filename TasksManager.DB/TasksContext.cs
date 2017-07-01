using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManager.Entities;

namespace TasksManager.DB
{
    public class TasksContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagsInTask> TagsInTask { get; set; }
    }
}
