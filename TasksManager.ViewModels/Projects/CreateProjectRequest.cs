﻿using System.ComponentModel.DataAnnotations;

namespace TasksManager.ViewModels.Projects
{
    public class CreateProjectRequest
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }
    }
}
