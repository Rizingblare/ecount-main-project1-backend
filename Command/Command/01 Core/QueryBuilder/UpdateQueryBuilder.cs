using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class UpdateQueryBuilder : BaseQueryBuilder<UpdateQueryBuilder>
    {
        private List<string> setClauses = new List<string>();
        private string table;

        public UpdateQueryBuilder Update(string table)
        {
            this.table = table;
            return this;
        }

        public UpdateQueryBuilder Set(string column, string paramName, object paramValue)
        {
            setClauses.Add($"{column} = @{paramName}");
            parameters[paramName] = paramValue;
            return this;
        }

        public override string GenerateQuery()
        {
            query.Append($"UPDATE {table} SET ");
            query.Append(string.Join(", ", setClauses)).Append(" ");

            BuildWhereClause();

            return query.ToString().Trim();
        }
    }
}
