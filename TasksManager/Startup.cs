using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using TasksManager.DataAccess.DbImplementation.Projects;
using TasksManager.DataAccess.DbImplementation.Tasks;
using TasksManager.DataAccess.Projects;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;

namespace TasksManager
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TasksContext>(option=>
                option.UseSqlServer(Configuration.GetConnectionString("TasksContext"))
            );
            RegisterQueriesAndCommands(services);
            // Add framework services.
            services.AddMvc();

            //add AutoMapper
            services.AddAutoMapper(typeof(Startup));
            
            //Add swagger
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", 
                        new Info {
                            Title ="Project management API",
                            Version ="v1",
                            Description = "API for management projects that consists of tasks",
                            TermsOfService = "None",
                            License = new License { Name="Use under MIT" },
                            Contact = new Contact { Name="Taihon", Url = "https://taihon.github.io"}
                        });
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TasksContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            context.Database.Migrate();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project management API v1"));
        }

        private void RegisterQueriesAndCommands(IServiceCollection services)
        {
            services
                .AddScoped<IProjectQuery, ProjectQuery>()
                .AddScoped<IProjectsListQuery, ProjectsListQuery>()
                .AddScoped<ICreateProjectCommand, CreateProjectCommand>()
                .AddScoped<IUpdateProjectCommand, UpdateProjectCommand>()
                .AddScoped<IDeleteProjectCommand, DeleteProjectCommand>()
                .AddScoped<ICreateTaskCommand, CreateTaskCommand>()
                .AddScoped<ITaskQuery, TaskQuery>()
                .AddScoped<ITasksListQuery,TasksListQuery>()
                .AddScoped<IDeleteTaskCommand, DeleteTaskCommand>()
                .AddScoped<IUpdateTaskCommand,UpdateTaskCommand>()
                .AddScoped<IAddTagToTaskCommand,AddTagToTaskCommand>()
                .AddScoped<IRemoveTagFromTask,RemoveTagFromTask>()
                ;
        }
    }
}
