using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SelectRequestDto : BaseRequest
    {
        public List<string> SelectFields { get; set; } = new List<string>();
        public string TableName { get; set; }
        public List<WhereConditionDto> WhereConditions { get; set; } = new List<WhereConditionDto>();

        public SelectRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
