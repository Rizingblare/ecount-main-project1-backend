using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class RequestTestDTO : BaseRequest
    {
        private readonly string _header;
        public string Header { get; }

        private readonly string _body;
        public string Body { get; }

        public RequestTestDTO(string header, string body)
        {
            this._header = header;
            this._body = body;
        }
    }
}
