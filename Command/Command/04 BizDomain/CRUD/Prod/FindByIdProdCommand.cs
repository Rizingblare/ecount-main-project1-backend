using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class FindByIdProdCommand<TRequest, TResult> : FindByIdCommand<TRequest, TResult>
        where TRequest : BaseRequest
        where TResult : BaseResponse
    {
        //public override void Init() { }
        //public override bool CanExecute() { return true; }
        //public override void OnExecuting() { }
        public override void ExecuteCore() { }
        //public override void Executed() { }
    }
}
