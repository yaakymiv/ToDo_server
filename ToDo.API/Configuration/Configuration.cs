using FluentResults;
using MediatR;
using System.Reflection;
using ToDo.BLL.DTO.Tasks;
using ToDo.BLL.MediatR.Tasks.Create;
using ToDo.DAL.Repositories.Interfaces.Base;
using ToDo.DAL.Repositories.Realizations.Base;

namespace ToDo.API.Configuration
{
    public static class ConfigureServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IRepositoryBase<TaskDTO>, RepositoryBase<TaskDTO>>();
        }

        public static void AddMediatRHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateTaskCommand, Result<TaskDTO>>, CreateTaskHandler>();
        }
    }
}