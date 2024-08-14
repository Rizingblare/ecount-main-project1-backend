using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class BaseCommand<TInput, TOutput> : ICommand<TInput, TOutput>
    where TInput : BaseRequest
    where TOutput : BaseResponse
    {
        public void Execute(TInput input, TOutput output)
        {
            Init();
            if (!CanExecute()) return;
            OnExecuting();
            ExecuteCore(input, output);
            Executed();
        }

        public virtual void Init() { }
        public virtual bool CanExecute() { return true; }
        public virtual void OnExecuting() { }
        public abstract void ExecuteCore(TInput input, TOutput output);
        public virtual void Executed() { }

    }
}
