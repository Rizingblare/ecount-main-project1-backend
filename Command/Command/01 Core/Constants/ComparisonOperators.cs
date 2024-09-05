using System;
using System.Collections.Generic;

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
            And,
            In,
            Like
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
                { ComparisonOperator.And, " AND " },
                { ComparisonOperator.In, " IN " },
                { ComparisonOperator.Like, " LIKE " }

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