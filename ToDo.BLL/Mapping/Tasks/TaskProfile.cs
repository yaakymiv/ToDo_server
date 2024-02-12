using AutoMapper;
using ToDo.BLL.DTO.Tasks;
using Task = ToDo.DAL.Entities.Tasks.Task;

namespace ToDo.BLL.Mapping.Tasks
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDTO>().ReverseMap();
        }
    }
}