﻿using System;
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
            if (Req.Header.Equals("헤더"))
            {
                throw new CreateTestError("Error Message: Header에 헤더를 넣으면 안돼여 !!!");
            }
            if (Req.Body.Equals("바디"))
            {
                throw new CreateTestError("Error Message: Body에 바디를 넣으면 안돼여 !!!");
            }
            Console.WriteLine("### CreateProdCommand의 ExecuteCore 실행완료");
        }
        //public override void Executed() { }
    }
}
