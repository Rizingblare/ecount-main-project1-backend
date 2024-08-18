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
            where TResult : CommandResult, new()
        {
            var item = new PipeLineItem<TCommand, TResult>(command);
            items.Enqueue(item);
            return item;
        }
        /*
        - TCommand는 구체적인 Command 타입이 위치할 자리
        - Commmand 추상화 타입을 상속받으면 구현에서 TRequest와 TResult 제네릭에 대한 구체화를 요구함
        - TRequest와 TResult에 대한 구체화하는 Command 세부 클래스에서만 담당할 수 있도록 IExecutalbe 상속
        */

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
