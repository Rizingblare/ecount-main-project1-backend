using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class BaseCommand<TResult> : ICommand<TResult>
        where TResult : BaseResponse, new()
    {
        public TResult Result { get; set; }
        private List<BaseError> _errors = new List<BaseError>();
        public List<BaseError> Errors { get { return _errors; } }

        public BaseCommand()
        {
            Result = new TResult();
        }

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
