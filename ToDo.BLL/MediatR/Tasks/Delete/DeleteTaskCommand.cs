using FluentResults;
using MediatR;

namespace ToDo.BLL.MediatR.Tasks.Delete
{
    public record DeleteTaskCommand(int id)
        : IRequest<Result<int>>;
}