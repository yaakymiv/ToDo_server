using System.Transactions;
using ToDo.DAL.Repositories.Interfaces.Tasks;

namespace ToDo.DAL.Repositories.Interfaces.Base
{
    public interface IRepositoryWrapper
    {
        ITaskRepository TaskRepository { get; }

        public Task<int> SaveChangesAsync();

        public TransactionScope BeginTransaction();
    }
}