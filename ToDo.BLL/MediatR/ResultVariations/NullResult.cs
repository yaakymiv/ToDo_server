using FluentResults;

namespace ToDo.BLL.MediatR.ResultVariations
{
    public class NullResult<T> : Result<T>
    {
        public NullResult()
            : base()
        {
        }
    }
}