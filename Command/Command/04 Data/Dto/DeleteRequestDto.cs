using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class DeleteRequestDto : BaseRequest
    {
        public string TableName { get; set; }
        public List<WhereConditionDto> WhereConditions { get; set; } = new List<WhereConditionDto>();

        public DeleteRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
