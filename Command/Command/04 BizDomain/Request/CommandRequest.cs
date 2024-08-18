using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class CommandRequest
    {
        public string Header { get; set; }
        public string Body { get; set; }
    }
}