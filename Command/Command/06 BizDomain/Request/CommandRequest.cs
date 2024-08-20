using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class CommandRequest : BaseRequest
    {
        public string Header { get; set; }
        public string Body { get; set; }
    }
}
