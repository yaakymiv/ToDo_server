using System.Transactions;
using ToDo.DAL.Persistence;
using ToDo.DAL.Repositories.Interfaces.Base;
using ToDo.DAL.Repositories.Interfaces.Tasks;
using ToDo.DAL.Repositories.Realizations.Tasks;

namespace ToDo.DAL.Repositories.Realizations.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ToDoDbContext _ToDoDbContext;

        private ITaskRepository _TaskRepository;

        public RepositoryWrapper(ToDoDbContext streetcodeDbContext)
        {
            _ToDoDbContext = streetcodeDbContext;
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                _TaskRepository ??= new TaskRepository(_ToDoDbContext);
                return _TaskRepository;
            }
        }


        public int SaveChanges()
        {
            return _ToDoDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ToDoDbContext.SaveChangesAsync();
        }

        public TransactionScope BeginTransaction()
        {
            return new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}