using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
                .ForMember(dest=>dest.CreateDate, opt=>opt.MapFrom(src=>DateTime.Now))
                //.ForMember(dest=>dest.Tags,o=>o.MapFrom(src=>src.Tags.ToList()))
                ;
            //CreateMap<Entities.TaskStatus, ViewModels.TaskStatus>();
            CreateMap<Entities.Task, TaskResponse>()
                .ForMember(d => d.Tags, o => o.MapFrom(
                    s => s.Tags.Select(tag => tag.Tag.Name).ToArray()))
                .ForMember(d=>d.Status,s=>s.MapFrom(o=>(ViewModels.TaskStatus)(int)o.Status));
            CreateMap<UpdateTaskRequest, Entities.Task>();
            CreateMap<String, Tag>()
                .ForMember(t => t.Name, opt => opt.MapFrom(src => src));
            CreateMap<Tag, TagsInTask>();
            CreateMap<String, TagsInTask>()
                .ForMember(t => t.Tag, o => o.MapFrom(src => src));
                ;
            //CreateMap<TagsInTask, Entities.Task>();
            //CreateMap<Entities.Task, TagsInTask>();
        }
    }
}
