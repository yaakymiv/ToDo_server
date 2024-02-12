using Microsoft.AspNetCore.Mvc;
using ToDo.BLL.DTO.Tasks;
using ToDo.BLL.MediatR.Tasks.Create;
using ToDo.BLL.MediatR.Tasks.Delete;
using ToDo.BLL.MediatR.Tasks.GetAll;

namespace ToDo.API.Controllers.Tasks
{
    public class TaskController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleResult(await Mediator.Send(new GetAllTasksQuery()));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDTO taskDto)
        {
            return HandleResult(await Mediator.Send(new CreateTaskCommand(taskDto)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteTaskCommand(id)));
        }
        
        // [HttpPut]
        // public async Task<IActionResult> Update([FromBody]JobDto jobDto)
        // {
        //     return HandleResult(await Mediator.Send(new UpdateJobCommand(jobDto)));
        // }
    }
}
