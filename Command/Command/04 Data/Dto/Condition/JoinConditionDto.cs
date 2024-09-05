using System.Collections.Generic;

namespace Command
{
    public class JoinConditionDTO
    {
        public string JoinType { get; set; } = "INNER";
        public string TableName { get; set; }
        public List<BaseConditionDTO> OnConditions { get; set; } = new List<BaseConditionDTO>();
    }
}
