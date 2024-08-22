using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class DeleteQueryBuilder : BaseQueryBuilder<DeleteQueryBuilder>
    {
        private string table;

        public DeleteQueryBuilder From(string table)
        {
            this.table = table;
            return this;
        }

        public override string GenerateQuery()
        {
            query.Append($"DELETE FROM {table} ");
            BuildWhereClause();
            return query.ToString().Trim();
        }
    }

}
