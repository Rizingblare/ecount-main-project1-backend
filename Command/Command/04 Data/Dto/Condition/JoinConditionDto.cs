using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class JoinConditionDto
    {
        public string JoinType { get; set; } = "INNER";
        public string TableName { get; set; }
        public List<ConditionDto> OnConditions { get; set; } = new List<ConditionDto>();
    }
}
