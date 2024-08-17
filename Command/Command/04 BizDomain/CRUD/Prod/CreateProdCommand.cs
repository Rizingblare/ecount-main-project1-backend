using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class CreateProdCommand<TRequest, TResult> : CreateCommand<TRequest, TResult>
        where TRequest : BaseRequest
        where TResult : BaseResponse
    {
        public override void Init()
        {
            base.Init();
            Console.WriteLine("CreateProd 초기화 !!!!");
        }
        //public override bool CanExecute() { return true; }
        //public override void OnExecuting() { }
        public override void ExecuteCore()
        {
            Console.WriteLine($"{input.Body}를 가지고 막 생성하려고 이리저리 로직을 타고 도는 중~~");
        }
        //public override void Executed() { }
    }
}
