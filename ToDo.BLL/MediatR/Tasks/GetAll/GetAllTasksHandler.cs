using AutoMapper;
using FluentResults;
using MediatR;
using ToDo.BLL.DTO.Tasks;
using ToDo.DAL.Repositories.Interfaces.Base;

namespace ToDo.BLL.MediatR.Tasks.GetAll
{
    internal class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, Result<IEnumerable<TaskDTO>>>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public GetAllTasksHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<TaskDTO>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tasks = await _repositoryWrapper.TaskRepository.GetAllAsync();
                var tasksDto = _mapper.Map<IEnumerable<TaskDTO>>(tasks);
                return Result.Ok(tasksDto);
            }
            catch(Exception ex)
            {
                return Result.Fail<IEnumerable<TaskDTO>>(ex.Message);
            }
        }
    }
}