using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class PipeLineItem<TCommand, TResult> : IPipeLineItem
        where TCommand : ICommand
        where TResult : BaseResponse, new()
    {
        private List<BaseError> _errors = new List<BaseError>();
        public List<BaseError> Errors { get { return _errors; } }
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
            _command.Execute();
            dynamic dCommand = _command;
            try
            {
                _result = dCommand.Result;
            }
            catch
            {
                throw new Exception("올바른 커맨드 타입이 아닙니다.");
            }

            _executed?.Invoke(_result);
        }

        public PipeLineItem<TCommand, TResult> AddFilter(Predicate<TCommand> filter = null)
        {
            this._filter += filter;
            return this;
        }
        public PipeLineItem<TCommand, TResult> Mapping(Action<TCommand> mapper = null)
        {
            this._mapper += mapper;
            return this;
        }
        public PipeLineItem<TCommand, TResult> Executed(Action<TResult> executed = null)
        {
            this._executed += executed;
            return this;
        }
    }
}
