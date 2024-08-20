using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.SelectProductDac;

namespace CommandTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pipeLine = new PipeLine();
            object result;
            pipeLine.Register<SelectProductDac, CommandResultWithBody<List<Product>>>(new SelectProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) => {
                        cmd.Request = new SelectProductDacRequestDto()
                        {
                            ComCode = "80000",
                            ProdCd = "test_cd"
                        };
                    })
                    .Executed((res) => {
                        foreach (var r in res.Body)
                        {
                            Console.WriteLine(r.WRITE_DT);
                            Console.WriteLine(r.PRICE);
                        }
                        result = res;
                        });

            pipeLine.Execute();
        }
    }
}
