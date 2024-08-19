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

            // # 1
            var createCmd = new CreateProdCommand();
            var createReq = new CreateCommandRequest("HTTP 1.1 / POST", "품목 id1 생성");

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

            // # 2
            var createCmd2 = new CreateProdCommand();
            var createReq2 = new CreateCommandRequest("HTTP 1.1 / POST", "바디");

            pipe.Register<CreateProdCommand, CommandResult>(createCmd2)
                .AddFilter((cmd) => {
                    Console.WriteLine("\n# AddFilter 작동");
                    return true;
                })
                .Mapping((cmd) => {
                    Console.WriteLine("# Mapping 콜백 함수 클로저와 Command Request 매핑");
                    cmd.Req = createReq2;
                })
                .Executed((result) => Console.WriteLine("# result에 Executed 적용\n"));

            // # 3
            var createCmd3 = new CreateProdCommand();
            var createReq3 = new CreateCommandRequest("헤더", "품목 id3 생성");

            pipe.Register<CreateProdCommand, CommandResult>(createCmd3)
                .AddFilter((cmd) => {
                    Console.WriteLine("\n# AddFilter 작동");
                    return true;
                })
                .Mapping((cmd) => {
                    Console.WriteLine("# Mapping 콜백 함수 클로저와 Command Request 매핑");
                    cmd.Req = createReq3;
                })
                .Executed((result) => Console.WriteLine("# result에 Executed 적용\n"));

            // # 4
            var createCmd4 = new CreateProdCommand();
            var createReq4 = new CreateCommandRequest("HTTP 1.1 / GET", "품목 id4 생성");

            pipe.Register<CreateProdCommand, CommandResult>(createCmd3)
                .AddFilter((cmd) => {
                    Console.WriteLine("\n# AddFilter 작동");
                    return true;
                })
                .Mapping((cmd) => {
                    Console.WriteLine("# Mapping 콜백 함수 클로저와 Command Request 매핑");
                    cmd.Req = createReq4;
                })
                .Executed((result) => Console.WriteLine("# result에 Executed 적용\n"));

            pipe.Execute();
        }
    }
}
