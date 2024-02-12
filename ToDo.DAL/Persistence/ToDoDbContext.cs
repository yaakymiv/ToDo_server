using Microsoft.EntityFrameworkCore;
using Task = ToDo.DAL.Entities.Tasks.Task;

namespace ToDo.DAL.Persistence
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {
        }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }

        }
    }

