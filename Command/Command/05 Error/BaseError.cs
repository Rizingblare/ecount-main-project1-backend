using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    
    public abstract class BaseError : Exception
    {
        public int Code;
        public string Msg;
    }
}
