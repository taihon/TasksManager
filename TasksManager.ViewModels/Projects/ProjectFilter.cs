﻿namespace TasksManager.ViewModels.Projects
{
    public class ProjectFilter
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public RangeFilter<int> OpenTasksCount { get; set; }
    }
}
