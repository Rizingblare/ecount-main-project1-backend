using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Command.ComparisonOperators;

namespace Command
{
    public abstract class BaseQueryBuilder<T> where T : BaseQueryBuilder<T>
    {
        protected StringBuilder query = new StringBuilder();
        protected List<string> whereConditions = new List<string>();
        protected Dictionary<string, object> parameters = new Dictionary<string, object>();
        protected int parameterIndex = 0;

        public T Where(List<BaseConditionDTO> conditions)
        {
            foreach (var condition in conditions)
            {
                if (condition.IsComplexCondition && condition.Value is List<BaseConditionDTO> subConditions)
                {
                    // 복합 조건 (AND/OR) 처리
                    string subClause = BuildComplexCondition(subConditions, condition.IsOrCondition ? "OR" : "AND");
                    whereConditions.Add($"({subClause})");
                }
                else if (condition.IsInCondition && condition.Value is IEnumerable<object> values)
                {
                    // IN 조건 처리
                    string inClause = string.Join(", ", values.Select(v => AddParameter(v)));
                    whereConditions.Add($"{condition.LeftField} IN ({inClause})");
                }
                else if (condition is LikeConditionDTO)
                {
                    whereConditions.Add($"({condition.LeftField} LIKE '%{condition.Value}%')");
                }

                else if (condition is BetweenConditionDTO)
                {
                    whereConditions.Add($"(BETWEEN {AddParameter(condition.LeftField)} AND {AddParameter(condition.Value)})");
                }
                else
                {
                    // 단일 조건 처리
                    string paramPlaceholder = AddParameter(condition.Value);
                    string operatorString = ComparisonOperatorConverter.ToSqlOperator(condition.Operator);
                    whereConditions.Add($"{condition.LeftField} {operatorString} {paramPlaceholder}");
                }
            }

            return (T)this;
        }

        private string BuildComplexCondition(List<BaseConditionDTO> subConditions, string logicalOperator)
        {
            List<string> conditionClauses = new List<string>();
            foreach (var subCondition in subConditions)
            {
                if (subCondition.Value is List<BaseConditionDTO> outerCondition)
                {
                    List<string> outerConditionClauses = new List<string>();
                    foreach (var innerCondition in outerCondition)
                    {
                        string paramPlaceholder = AddParameter(innerCondition.Value);
                        string operatorString = ComparisonOperatorConverter.ToSqlOperator(innerCondition.Operator);
                        outerConditionClauses.Add($"{innerCondition.LeftField} {operatorString} {paramPlaceholder}");
                    }
                    conditionClauses.Add($"({string.Join(" AND ", outerConditionClauses)})");
                }
            }

            return string.Join($" {logicalOperator} ", conditionClauses);
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
