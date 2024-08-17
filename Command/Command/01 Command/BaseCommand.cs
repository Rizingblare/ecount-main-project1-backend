using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class BaseCommand<TRequest, TResult> : BaseRequest, ICommand<TRequest, TResult>
    where TRequest : BaseRequest
    where TResult : BaseResponse
    {
        public void Execute()
        {
            Init();
            if (!CanExecute()) return;
            OnExecuting();
            ExecuteCore();
            Executed();
        }

        public virtual void Init() { }
        public virtual bool CanExecute() { return true; }
        public virtual void OnExecuting() { }
        public abstract void ExecuteCore();
        public virtual void Executed() { }

    }
}
