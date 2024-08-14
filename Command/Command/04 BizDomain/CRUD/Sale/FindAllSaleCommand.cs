using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class FindAllSaleCommand<TInput, TOutput> : FindAllCommand<TInput, TOutput>
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
