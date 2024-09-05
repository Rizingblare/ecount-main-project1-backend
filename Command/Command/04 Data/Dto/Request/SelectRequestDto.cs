using System.Collections.Generic;

namespace Command
{
    public class SelectRequestDto : BaseRequest
    {
        public List<string> Fields { get; set; } = new List<string>();
        public string TableName { get; set; }
        public List<BaseConditionDTO> WhereConditions { get; set; } = new List<BaseConditionDTO>();
        public List<OrderByConditionDto> OrderByConditions { get; set; } = new List<OrderByConditionDto>();
        public List<JoinConditionDTO> JoinConditions { get; set; } = new List<JoinConditionDTO>();
        public int? Limit { get; set; }
        public int? Offset { get; set; }

        public SelectRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
