using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.ComparisonOperators;

namespace Command
{
    public class BaseConditionDTO
    {
        public string LeftField { get; set; }
        public ComparisonOperator Operator { get; set; } = ComparisonOperator.Equal;
        public object Value { get; set; }
        public bool IsInCondition { get; set; } = false;
        public bool IsComplexCondition { get; set; } = false;
        public bool IsOrCondition { get; set; } = false;
        public bool IsFieldName { get; set; } = false;
    }
}
