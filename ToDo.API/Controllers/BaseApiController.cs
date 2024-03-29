using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.BLL.MediatR.ResultVariations;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;

        public BaseApiController()
        {
        }

        protected IMediator Mediator => _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()!;

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (!result.IsSuccess)
            {
                return BadRequest(result.Reasons);
            }

            if (result is NullResult<T>)
            {
                return Ok(result.Value);
            }

            return (result.Value is null) ? NotFound("Not Found") : Ok(result.Value);
        }
    }
}