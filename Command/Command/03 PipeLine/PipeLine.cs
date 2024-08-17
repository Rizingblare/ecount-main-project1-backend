using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class PipeLine : IExecutable
    {
        private Queue<IPipeLineItem> items;

        public PipeLine()
        {
            this.items = new Queue<IPipeLineItem>();
        }

        public PipeLineItem<TCommand, TResult> Register<TCommand, TResult>(TCommand command)
            where TCommand : IExecutable
            where TResult : BaseResponse
        {
            var item = new PipeLineItem<TCommand, TResult>(command);
            items.Enqueue(item);
            return item;
        }


        public void Execute()
        {
            while(items.Count > 0)
            {
                var item = items.Dequeue();
                item.Execute();
            }
        }
    }
}
