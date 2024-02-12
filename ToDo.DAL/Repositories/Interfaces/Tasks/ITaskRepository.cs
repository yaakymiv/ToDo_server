using ToDo.DAL.Repositories.Interfaces.Base;
using Task = ToDo.DAL.Entities.Tasks.Task;

namespace ToDo.DAL.Repositories.Interfaces.Tasks
{
	public interface ITaskRepository : IRepositoryBase<Task>
	{
	}
}