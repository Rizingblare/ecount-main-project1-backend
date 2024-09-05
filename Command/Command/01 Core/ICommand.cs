using System.Collections.Generic;

namespace Command
{
    public interface ICommand
    {
        List<BaseError> Errors { get; }
        void Execute();
    }
    public interface ICommand<TResult> : ICommand
        where TResult : BaseResponse
    {
        TResult Result { get; set; }
    }
    public interface ICommand<TRequest, TResult> : ICommand
        where TRequest : BaseRequest
        where TResult : BaseResponse
    {
        TRequest Request { get; set; }
        TResult Result { get; set; }
    }
}
