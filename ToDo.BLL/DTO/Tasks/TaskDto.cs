namespace ToDo.BLL.DTO.Tasks
{
    public class TaskDTO
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        //'TaskStatus' is ambiguous so I needed to explicitly type it
        public ToDo.DAL.Enums.TaskStatus Status { get; set; }
        
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}