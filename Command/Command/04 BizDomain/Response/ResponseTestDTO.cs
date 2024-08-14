using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class ResponseTestDTO : BaseResponse
    {
        private readonly string _success;
        public string Header { get; }

        private readonly string _response;
        public string Body { get; }

        private readonly string _error;
        public string Error { get; }

        public ResponseTestDTO(string success, string response, string error)
        {
            this._success = success;
            this._response = response;
            this._error = error;
        }
    }
}
