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
        public object Value { get; set; } // 조건 값 (단일 값 또는 리스트)
        public bool IsInCondition { get; set; } = false; // IN 조건인지 여부
    }
}
