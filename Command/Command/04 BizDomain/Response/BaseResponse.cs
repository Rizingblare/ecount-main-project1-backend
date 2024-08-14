using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Command
{
    public abstract class BaseResponse {
        private readonly string _success;
        public string Header { get; }

        private readonly string _response;
        public string Body { get; }

        private readonly string _error;
        public string Error { get; }
    }
}