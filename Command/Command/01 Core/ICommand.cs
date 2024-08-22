using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface ICommand
    {
        List<BaseError> Errors { get; }
        void Execute();
    }
    public interface ICommand<TResult>
        where TResult : BaseResponse
    {
        TResult Result { get; set; }
        List<BaseError> Errors { get; }
        void Execute();
    }
    public interface ICommand <TRequest, TResult>
        where TRequest : BaseRequest
        where TResult : BaseResponse
    {
        TRequest Request { get; set; }
        TResult Result { get; set; }
        List<BaseError> Errors { get; }
        void Execute();
    }
}
