using FluentResults;
using MediatR;
using ToDo.DAL.Repositories.Interfaces.Base;

namespace ToDo.BLL.MediatR.Tasks.Delete
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Result<int>>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public DeleteTaskHandler(IRepositoryWrapper repository)
        {
            _repositoryWrapper = repository;
        }

        public async Task<Result<int>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskToDelete =
                await _repositoryWrapper.TaskRepository.GetFirstOrDefaultAsync(x => x.Id == request.id);
            if (taskToDelete is null)
            {
                string exMessage = $"No task found by entered Id - {request.id}";
                return Result.Fail(exMessage);
            }

            try
            {
                _repositoryWrapper.TaskRepository.Delete(taskToDelete);
                await _repositoryWrapper.SaveChangesAsync();
                return Result.Ok(request.id);
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}