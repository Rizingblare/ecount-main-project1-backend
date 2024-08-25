using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.ComparisonOperators;

namespace Command
{
    public class ConditionDto
    {
        public string LeftField { get; set; }
        public ComparisonOperator Operator { get; set; } = ComparisonOperator.Equal;
        public string RightField { get; set; }
        public object RightValue { get; set; }
    }
}
