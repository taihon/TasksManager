using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TasksManager.Entities;
using TasksManager.ViewModels.Projects;
using TasksManager.ViewModels.Tasks;

namespace TasksManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectResponse>();
            CreateMap<UpdateProjectRequest, Project>();
            CreateMap<CreateTaskRequest, Entities.Task>()
                .ForMember(dest=>dest.CreateDate, opt=>opt.MapFrom(src=>DateTime.Now));
            CreateMap<Entities.Task,TaskResponse>();
        }
    }
}
