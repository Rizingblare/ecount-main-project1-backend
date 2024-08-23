using System;
using System.Collections.Generic;
using System.Linq;
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

        public T Where(List<WhereConditionDto> conditions)
        {
            foreach (var condition in conditions)
            {
                string operatorString = ComparisonOperatorConverter.ToSqlOperator(condition.Operator);
                var paramPlaceholder = AddParameter(condition.Value);
                whereConditions.Add($"{condition.FieldName} {operatorString} {paramPlaceholder}");
            }
            return (T)this;
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
