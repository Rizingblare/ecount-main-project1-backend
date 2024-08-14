using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class BaseRequest
    {
        private readonly string _header;
        public string Header { get; }

        private readonly string _body;
        public string Body { get; }
    }
}