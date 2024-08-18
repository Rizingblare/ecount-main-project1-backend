using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pipe = new PipeLine();
            var createCmd = new CreateProdCommand();
            var createReq = new CreateCommandRequest("HTTP 1.1 / POST", "Prod1 등록");

            pipe.Register<CreateProdCommand, CommandResult>(createCmd)
                .AddFilter((cmd) => {
                    Console.WriteLine("# AddFilter 작동");
                    return true;
                })
                .Mapping((cmd) => {
                    Console.WriteLine("# Mapping 콜백 함수 클로저와 Command Request 매핑");
                    cmd.Req = createReq;
                })
                .Executed((result) => Console.WriteLine("# result에 Executed 적용"));

            pipe.Execute();
        }
    }
}
