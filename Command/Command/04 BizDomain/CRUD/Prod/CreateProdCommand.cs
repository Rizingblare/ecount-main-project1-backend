using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class CreateProdCommand: CreateCommand<CreateCommandRequest, CommandResult>
    {
        public override void Init()
        {
            Console.WriteLine("### CreateProdCommand Init");
            base.Init();
        }
        //public override bool CanExecute() { return true; }
        //public override void OnExecuting() { }
        public override void ExecuteCore()
        {
            Console.WriteLine("### CreateProdCommand의 ExecuteCore 실행");
            Console.WriteLine($"### 현재 Command의 Request Header는 {Req.Header}");
            Console.WriteLine($"### 현재 Command의 Request Body는 {Req.Body}");
        }
        //public override void Executed() { }
    }
}
