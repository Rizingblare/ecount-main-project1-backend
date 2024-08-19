using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class CreateTestError : BaseError
    {
        public CreateTestError(string msg)
        {
            base.Code = 2000;
            base.Msg = msg;
        }
    }
}