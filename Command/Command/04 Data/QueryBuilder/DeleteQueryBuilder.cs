using System.Collections.Generic;

namespace Command
{
    public class DeleteQueryBuilder : BaseQueryBuilder<DeleteQueryBuilder>
    {
        private string table;

        public DeleteQueryBuilder Delete(string table)
        {
            this.table = table;
            return this;
        }

        public override (string, Dictionary<string, object>) Build()
        {
            query.Append($"DELETE FROM {table} ");
            BuildWhereClause();
            return (query.ToString().Trim(), parameters);
        }
    }

}
