using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class BasePipeLine<ICommand, TOutPut> : ICommand
    where TCommand : BaseCommand<TCommand, TOutput>
    where TOutput : BaseResponse
    {
        private Queue<IPipeLineItem> Items;

        public BasePipeLineItem Register (TCommand command)
            where 고민
        {}


        void Execute(TCommand input, TOutput output)
        {
            // Command 들을 실행하는 동작
        }
}
