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
        private List<string> _selectFields = new List<string>();
        private string _table;
        private List<string> _orderByClauses = new List<string>();
        private List<string> _joinClauses = new List<string>();
        private int? _limit;
        private int? _offset;


        public SelectQueryBuilder Select(List<string> fields = null)
        {
            if (fields != null && fields.Any())
            {
                _selectFields.AddRange(fields);
            }
            return this;
        }

        public SelectQueryBuilder From(string table)
        {
            this._table = table;
            return this;
        }


        public SelectQueryBuilder Join(List<JoinConditionDto> conditions)
        {
            foreach (var join in conditions)
            {
                List<string> onClauses = new List<string>();

                foreach (var condition in join.OnConditions)
                {
                    var rightside = condition.IsFieldName ? (string) condition.Value : AddParameter(condition.Value);
                    onClauses.Add($"{condition.LeftField} {ComparisonOperatorConverter.ToSqlOperator(condition.Operator)} {rightside}");
                }

                var joinClause = $"{join.JoinType} JOIN {join.TableName} ON {string.Join(" AND ", onClauses)}";
                _joinClauses.Add(joinClause);
            }
            return this;
        }

        public SelectQueryBuilder OrderBy(List<OrderByConditionDto> conditions = null)
        {
            foreach (var condition in conditions)
            {
                var orderByClause = $"{condition.FieldName} {condition.SortDirection}";
                _orderByClauses.Add(orderByClause);
            }
            return this;
        }
        public SelectQueryBuilder Limit(int? limit)
        {
            this._limit = limit;
            return this;
        }

        public SelectQueryBuilder Offset(int? offset)
        {
            this._offset = offset;
            return this;
        }

        public override (string, Dictionary<string, object>) Build()
        {
            if (_selectFields.Any())
            {
                query.Append($"SELECT {string.Join(", ", _selectFields)} ");
            }
            else
            {
                query.Append("SELECT * ");
            }

            query.Append($"FROM {_table} ");

            if (_joinClauses.Any())
            {
                query.Append(string.Join(" ", _joinClauses)).Append(" ");
            }

            BuildWhereClause();

            if (_orderByClauses.Any())
            {
                query.Append("ORDER BY ");
                query.Append(string.Join(", ", _orderByClauses)).Append(" ");
            }

            if (_limit.HasValue)
            {
                query.Append($"LIMIT {_limit.Value} ");
            }

            if (_offset.HasValue)
            {
                query.Append($"OFFSET {_offset.Value} ");
            }

            return (query.ToString().Trim(), parameters);
        }
    }
}
