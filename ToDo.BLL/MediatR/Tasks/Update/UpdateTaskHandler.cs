using AutoMapper;
using FluentResults;
using MediatR;
using ToDo.BLL.DTO.Tasks;
using ToDo.DAL.Repositories.Interfaces.Base;
using Task = ToDo.DAL.Entities.Tasks.Task;

namespace ToDo.BLL.MediatR.Tasks.Update
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, Result<TaskDTO>>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public UpdateTaskHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repositoryWrapper = repository;
            _mapper = mapper;
        }

        public async Task<Result<TaskDTO>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var existedTask =
                await _repositoryWrapper.TaskRepository.GetFirstOrDefaultAsync(x => x.Id == request.task.Id);
            if (existedTask is null)
            {
                string exMessage = $"No task found by entered Id - {request.task.Id}";
                return Result.Fail(exMessage);
            }

            try
            {
                var taskToUpdate = _mapper.Map<Task>(request.task);
                _repositoryWrapper.TaskRepository.Update(taskToUpdate);
                await _repositoryWrapper.SaveChangesAsync();
                return Result.Ok(_mapper.Map<TaskDTO>(taskToUpdate));
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
    }
}