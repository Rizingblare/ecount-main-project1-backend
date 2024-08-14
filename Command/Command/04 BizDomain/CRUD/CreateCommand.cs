using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class CreateCommand<TInput, TOutput> : BaseCommand<TInput, TOutput>
        where TInput : BaseRequest
        where TOutput : BaseResponse
    {
        
        public override void Init() {
            Console.WriteLine("Create 초기화 !!!!");
        }
        // public override bool CanExecute() { return true; }
        // public override void OnExecuting() { }
        // public override void ExecuteCore();
        // public override void Executed() { }
        
    }
}
