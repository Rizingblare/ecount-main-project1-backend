using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class InsertRequestDto : BaseRequest
    {
        public string TableName { get; set; }
        public Dictionary<string, object> FieldValues { get; set; } = new Dictionary<string, object>();

        public InsertRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
