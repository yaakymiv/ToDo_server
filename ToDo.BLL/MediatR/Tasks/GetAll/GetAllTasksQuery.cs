using FluentResults;
using MediatR;
using ToDo.BLL.DTO.Tasks;

namespace ToDo.BLL.MediatR.Tasks.GetAll
{
    public record GetAllTasksQuery()
        : IRequest<Result<IEnumerable<TaskDTO>>>;
}