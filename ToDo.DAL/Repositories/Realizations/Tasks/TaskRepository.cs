using ToDo.DAL.Persistence;
using ToDo.DAL.Repositories.Interfaces.Tasks;
using ToDo.DAL.Repositories.Realizations.Base;
using Task = ToDo.DAL.Entities.Tasks.Task;

namespace ToDo.DAL.Repositories.Realizations.Tasks
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(ToDoDbContext context)
            : base(context)
        {
        }
    }
}