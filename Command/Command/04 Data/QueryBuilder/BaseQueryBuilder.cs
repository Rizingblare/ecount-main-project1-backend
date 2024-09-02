using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using static Command.ComparisonOperators;

namespace Command
{
    public abstract class BaseQueryBuilder<T> where T : BaseQueryBuilder<T>
    {
        protected StringBuilder query = new StringBuilder();
        protected List<string> whereConditions = new List<string>();
        protected Dictionary<string, object> parameters = new Dictionary<string, object>();
        protected int parameterIndex = 0;

        public T Where(List<ConditionDto> conditions)
        {
            foreach (var condition in conditions)
            {
                if (condition.IsInCondition && condition.Value is IEnumerable<object> values)
                {
                    // IN 조건 처리
                    string inClause = string.Join(", ", values.Select(v => AddParameter(v)));
                    whereConditions.Add($"{condition.LeftField} IN ({inClause})");
                }
                else
                {
                    // 단일 조건 처리
                    string paramPlaceholder = AddParameter(condition.Value);
                    string operatorString = ComparisonOperatorConverter.ToSqlOperator(condition.Operator);
                    whereConditions.Add($"{condition.LeftField} {operatorString} {paramPlaceholder}");
                }
            }

            return (T) this;
        }

        protected string AddParameter(object value)
        {
            var paramPlaceholder = $"@param{parameterIndex++}";
            parameters[paramPlaceholder] = value;
            return paramPlaceholder;
        }

        protected void BuildWhereClause()
        {
            if (whereConditions.Any())
            {
                query.Append("WHERE ");
                query.Append(string.Join(" AND ", whereConditions)).Append(" ");
            }
        }

        public Dictionary<string, object> GetParameters()
        {
            return parameters;
        }

        public abstract (string Query, Dictionary<string, object> Parameters) Build();
    }
}
