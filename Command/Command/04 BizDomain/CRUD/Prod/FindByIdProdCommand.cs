using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class FindByIdProdCommand<TInput, TOutput> : FindByIdCommand<TInput, TOutput>
        where TInput : BaseRequest
        where TOutput : BaseResponse
    {
        //public override void Init() { }
        //public override bool CanExecute() { return true; }
        //public override void OnExecuting() { }
        public override void ExecuteCore(TInput input, TOutput output) { }
        //public override void Executed() { }
    }
}
