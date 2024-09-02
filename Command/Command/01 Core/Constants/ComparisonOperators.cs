using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class ComparisonOperators
    {
        public enum ComparisonOperator
        {
            Equal,
            NotEqual,
            GreaterThan,
            LessThan,
            GreaterOrEqual,
            LessOrEqual,
            In
        }

        public static class ComparisonOperatorConverter
        {
            private static readonly Dictionary<ComparisonOperator, string> OperatorMappings = new Dictionary<ComparisonOperator, string>
            {
                { ComparisonOperator.Equal, "=" },
                { ComparisonOperator.NotEqual, "<>" },
                { ComparisonOperator.GreaterThan, ">" },
                { ComparisonOperator.LessThan, "<" },
                { ComparisonOperator.GreaterOrEqual, ">=" },
                { ComparisonOperator.LessOrEqual, "<=" },
                { ComparisonOperator.In, " IN " }

            };

            public static string ToSqlOperator(ComparisonOperator comparisonOperator)
            {
                if (OperatorMappings.TryGetValue(comparisonOperator, out var sqlOperator))
                {
                    return sqlOperator;
                }

                throw new NotImplementedException();
            }
        }

    }
}