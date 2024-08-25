using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class UpdateRequestDto : BaseRequest
    {
        public string TableName { get; set; }
        public Dictionary<string, object> SetFields { get; set; } = new Dictionary<string, object>();
        public List<ConditionDto> WhereConditions { get; set; } = new List<ConditionDto>();

        public UpdateRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
