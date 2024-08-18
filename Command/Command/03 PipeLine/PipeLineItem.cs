using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class PipeLineItem<TCommand, TResult> : IPipeLineItem
        where TCommand : IExecutable
        where TResult : CommandResult, new()
    {
        private TCommand _command;
        private Predicate<TCommand> _filter;
        private Action<TCommand> _mapper;
        private Action<TResult> _executed;
        private TResult _result;

        public PipeLineItem(TCommand command)
        {
            this._command = command;
            this._result = new TResult();
        }

        public void Execute()
        {
            OnExecute();
        }
        private void OnExecute()
        {
            if (_filter != null && !_filter(_command))
            {
                return;
            }
            if (_mapper != null)
            {
                _mapper(_command);
            }
            _command?.Execute();
            _executed?.Invoke(_result);

        }

        public PipeLineItem<TCommand, TResult> AddFilter(Predicate<TCommand> filter)
        {
            this._filter += filter;
            return this;
        }
        public PipeLineItem<TCommand, TResult> Mapping(Action<TCommand> mapper)
        {
            this._mapper += mapper;
            return this;
        }
        public PipeLineItem<TCommand, TResult> Executed(Action<TResult> executed)
        {
            this._executed += executed;
            return this;
        }
    }
}
