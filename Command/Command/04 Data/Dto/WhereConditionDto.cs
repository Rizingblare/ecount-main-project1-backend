using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.ComparisonOperators;

namespace Command
{
    public class WhereConditionDto
    {
        public string FieldName { get; set; }
        public object Value { get; set; }
        public ComparisonOperator Operator { get; set; } = ComparisonOperator.Equal;

        public WhereConditionDto(string FieldName, object Value) {
            this.FieldName = FieldName;
            this.Value = Value;
        }
    }
}
