using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TasksManager.Entities;
using TasksManager.ViewModels.Projects;
using TasksManager.ViewModels.Tags;
using TasksManager.ViewModels.Tasks;
using TaskStatus = TasksManager.Entities.TaskStatus;

namespace TasksManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Project mapping to and from
            CreateMap<Project, ProjectResponse>()
                .ForMember(d=>d.OpenTasksCount,o=>o.MapFrom(src=>src.Tasks.Count(t=>t.Status!=TaskStatus.Completed)))
                ;
            CreateMap<UpdateProjectRequest, Project>();
            CreateMap<CreateProjectRequest, Project>();
            //Project mapping to and from
            //Task mapping to and from
            CreateMap<CreateTaskRequest, Entities.Task>()
                .ForMember(dest=>dest.CreateDate, opt=>opt.MapFrom(src=>DateTime.Now))
                ;
            CreateMap<Entities.Task, TaskResponse>()
                .ForMember(d => d.Tags, o => o.MapFrom(
                    s => s.Tags.Select(tag => tag.Tag.Name).ToArray()))
                .ForMember(d=>d.Status,s=>s.MapFrom(o=>(ViewModels.TaskStatus)(int)o.Status));
            CreateMap<UpdateTaskRequest, Entities.Task>();
            //Task mapping to and from
            //Tag mapping to and from
            CreateMap<String, Tag>()
                .ForMember(t => t.Name, opt => opt.MapFrom(src => src));
            CreateMap<Tag, TagsInTask>();
            CreateMap<String, TagsInTask>()
                .ForMember(t => t.Tag, o => o.MapFrom(src => src));
            CreateMap<Tag, TagResponse>()
                .ForMember(d => d.OpenTaskCount,
                    opt => opt.MapFrom(src => src.Tasks.Count(t => t.Task.Status != TaskStatus.Completed)))
                .ForMember(d => d.TotalTaskCount, o => o.MapFrom(src => src.Tasks.Count))
                ;
            //Tag mapping to and from
        }
    }
}
