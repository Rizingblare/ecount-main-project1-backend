using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SelectRequestDto : BaseRequest
    {
        public List<string> Fields { get; set; } = new List<string>();
        public string TableName { get; set; }
        public List<BaseConditionDTO> WhereConditions { get; set; } = new List<BaseConditionDTO>();
        public List<OrderByConditionDto> OrderByConditions { get; set; } = new List<OrderByConditionDto>();
        public List<JoinConditionDto> JoinConditions { get; set; } = new List<JoinConditionDto>();
        public int? Limit { get; set; }
        public int? Offset { get; set; }

        public SelectRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
