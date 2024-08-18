using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class CreateCommandRequest : CommandRequest
    {
        public CreateCommandRequest(string header, string body)
        {
            this.Header = header;
            this.Body = body;
        }
    }
}
