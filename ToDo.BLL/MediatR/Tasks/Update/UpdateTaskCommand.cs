using FluentResults;
using MediatR;
using ToDo.BLL.DTO.Tasks;

namespace ToDo.BLL.MediatR.Tasks.Update
{
	public record UpdateTaskCommand(TaskDTO task)
		: IRequest<Result<TaskDTO>>;
}