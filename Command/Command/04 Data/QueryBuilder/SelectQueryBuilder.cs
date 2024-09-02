using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.ComparisonOperators;

namespace Command
{
    public class SelectQueryBuilder : BaseQueryBuilder<SelectQueryBuilder>
    {
        private List<string> selectFields = new List<string>();
        private string table;
        private List<string> orderByClauses = new List<string>();
        private List<string> joinClauses = new List<string>();
        private int? limit;
        private int? offset;


        public SelectQueryBuilder Select(List<string> fields = null)
        {
            if (fields != null && fields.Any())
            {
                selectFields.AddRange(fields);
            }
            return this;
        }

        public SelectQueryBuilder From(string table)
        {
            this.table = table;
            return this;
        }

        /*
        public SelectQueryBuilder Join(List<JoinConditionDto> conditions)
        {
            foreach (var join in conditions)
            {
                List<string> onClauses = new List<string>();

                foreach (var condition in join.OnConditions)
                {

                    string conditionRightSide = condition.RightField ?? AddParameter(condition.RightValue);
                    onClauses.Add($"{condition.LeftField} {ComparisonOperatorConverter.ToSqlOperator(condition.Operator)} {conditionRightSide}");
                }

                var joinClause = $"{join.JoinType} JOIN {join.TableName} ON {string.Join(" AND ", onClauses)}";  // 여러 조건을 AND로 연결
                joinClauses.Add(joinClause);
            }
            return this;
        }
        */

        public SelectQueryBuilder OrderBy(List<OrderByConditionDto> conditions = null)
        {
            foreach (var condition in conditions)
            {
                var orderByClause = $"{condition.FieldName} {condition.SortDirection}";
                orderByClauses.Add(orderByClause);
            }
            return this;
        }
        public SelectQueryBuilder Limit(int limit)
        {
            this.limit = limit;
            return this;
        }

        public SelectQueryBuilder Offset(int offset)
        {
            this.offset = offset;
            return this;
        }

        public override (string, Dictionary<string, object>) Build()
        {
            if (selectFields.Any())
            {
                query.Append($"SELECT {string.Join(", ", selectFields)} ");
            }
            else
            {
                query.Append("SELECT * ");
            }

            query.Append($"FROM {table} ");

            if (joinClauses.Any())
            {
                query.Append(string.Join(" ", joinClauses)).Append(" ");
            }

            BuildWhereClause();

            if (orderByClauses.Any())
            {
                query.Append("ORDER BY ");
                query.Append(string.Join(", ", orderByClauses)).Append(" ");
            }

            if (limit.HasValue)
            {
                query.Append($"LIMIT {limit.Value} ");
            }

            if (offset.HasValue)
            {
                query.Append($"OFFSET {offset.Value} ");
            }

            return (query.ToString().Trim(), parameters);
        }
    }
}
