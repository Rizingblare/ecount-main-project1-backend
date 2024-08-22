using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class ComparisonOperators
    {
        // ComparisonOperators.cs
        public enum ComparisonOperator
        {
            Equal,
            NotEqual,
            GreaterThan,
            LessThan,
            GreaterOrEqual,
            LessOrEqual
        }

        public static class ComparisonOperatorConverter
        {
            // 딕셔너리를 사용하여 연산자 매핑
            private static readonly Dictionary<ComparisonOperator, string> OperatorMappings = new Dictionary<ComparisonOperator, string>
            {
                { ComparisonOperator.Equal, "=" },
                { ComparisonOperator.NotEqual, "<>" },
                { ComparisonOperator.GreaterThan, ">" },
                { ComparisonOperator.LessThan, "<" },
                { ComparisonOperator.GreaterOrEqual, ">=" },
                { ComparisonOperator.LessOrEqual, "<=" }
            };

            // 열거형을 SQL 연산자로 변환하는 메서드
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