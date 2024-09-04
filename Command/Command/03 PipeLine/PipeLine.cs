using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class PipeLine : ICommand
    {
        public List<BaseError> Errors { get; } = new List<BaseError>();
        private Queue<IPipeLineItem> _items;
        public Dictionary<string, object> Contexts { get; } = new Dictionary<string, object>();

        public PipeLine()
        {
            this._items = new Queue<IPipeLineItem>();
        }

        public PipeLineItem<TCommand, TResult> Register<TCommand, TResult>(TCommand command)
            where TCommand : ICommand
            where TResult : BaseResponse, new()
        {
            var item = new PipeLineItem<TCommand, TResult>(command);
            _items.Enqueue(item);
            return item;
        }
        /*
        - TCommand는 구체적인 Command 타입이 위치할 자리
        - Commmand 추상화 타입을 상속받으면 구현에서 TRequest와 TResult 제네릭에 대한 구체화를 요구함
        - TRequest와 TResult에 대한 구체화하는 Command 세부 클래스에서만 담당할 수 있도록 IExecutalbe 상속
        */

        public void Execute()
        {
            int totalCount = _items.Count();
            while(_items.Count > 0)
            {
                var item = _items.Dequeue();
                try
                {
                    item.Execute();
                }
                catch (BaseError e)
                {
                    this.AddError(e);
                }
            }

            Console.WriteLine($"\n전체 {totalCount}개 커맨드 중 {totalCount - Errors.Count()}개 성공.\n");
            foreach (var error in Errors)
            {
                Console.WriteLine(error.Msg);
            }
        }
    }
}
