using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class PipeLineItem<TCommand, TResult> : IPipeLineItem
    {
        private TCommand command;
        private Predicate<TCommand> filter;
        private Func<TCommand, BaseRequest> mapper;
        private Action<TCommand> executed;

        public PipeLineItem(TCommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            OnExecute();
        }
        private void OnExecute()
        {
            if (filter != null && !filter(command))
            {
                return;
            }

            if (mapper != null)
            {
                
            }
        }

        public PipeLineItem<TCommand, TResult> AddFilter(Predicate<TCommand> filter)
        {
            this.filter = filter;
            return this;
        }
        public PipeLineItem<TCommand, TResult> Mapping(Func<TCommand, BaseRequest> mapper)
        {
            this.mapper = mapper;
            return this;
        }
        public PipeLineItem<TCommand, TResult> Executed(Action<TCommand> executed)
        {
            this.executed = executed;
            return this;
        }
    }
}
