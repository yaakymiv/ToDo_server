using MediatR;
using FluentResults;
using ToDo.BLL.DTO.Tasks;

namespace ToDo.BLL.MediatR.Tasks.Create
{
    public record CreateTaskCommand(TaskDTO task) : IRequest<Result<TaskDTO>>
    {
    }
}

