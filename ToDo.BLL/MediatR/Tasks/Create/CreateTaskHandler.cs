using AutoMapper;
using FluentResults;
using MediatR;
using ToDo.BLL.DTO.Tasks;
using ToDo.DAL.Repositories.Interfaces.Base;
using Task = ToDo.DAL.Entities.Tasks.Task;

namespace ToDo.BLL.MediatR.Tasks.Create
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Result<TaskDTO>>
    {
        private readonly IRepositoryBase<TaskDTO> _taskRepository;
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CreateTaskHandler(IRepositoryBase<TaskDTO> taskRepository,IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<Result<TaskDTO>> Handle(CreateTaskCommand request,CancellationToken cancellationToken)
        {
            try
            {
                var task = _mapper.Map<Task>(request.task);
                if (!task.StartDate.HasValue)
                {
                    task.StartDate = DateTime.Now;
                    task.EndDate = task.StartDate.Value.AddDays(1);
                }
                
                var createdTask = await _repositoryWrapper.TaskRepository.CreateAsync(task);
                await _repositoryWrapper.SaveChangesAsync();
                
                return Result.Ok(_mapper.Map<TaskDTO>(createdTask));
            }
            catch (Exception ex)
            {
                return Result.Fail<TaskDTO>($"Failed to create task: {ex.Message}");
            }
        }
    }
}