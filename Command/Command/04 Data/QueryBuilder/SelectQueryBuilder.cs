using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SelectQueryBuilder : BaseQueryBuilder<SelectQueryBuilder>
    {
        private List<string> selectFields = new List<string>();
        private string table;
        private List<string> orderByFields = new List<string>();

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

        public SelectQueryBuilder OrderBy(List<string> fields)
        {
            orderByFields.AddRange(fields);
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
            BuildWhereClause();

            if (orderByFields.Any())
            {
                query.Append("ORDER BY ");
                query.Append(string.Join(", ", orderByFields)).Append(" ");
            }

            return (query.ToString().Trim(), parameters);
        }
    }
}
