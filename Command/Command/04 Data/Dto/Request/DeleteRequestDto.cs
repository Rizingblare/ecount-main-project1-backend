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
        public List<BaseConditionDTO> WhereConditions { get; set; } = new List<BaseConditionDTO>();

        public DeleteRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
