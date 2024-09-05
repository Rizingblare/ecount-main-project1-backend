using System.Collections.Generic;

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

        public UpdateQueryBuilder Set(Dictionary<string, object> fieldValues)
        {
            foreach (var field in fieldValues)
            {
                var paramPlaceholder = AddParameter(field.Value);
                setClauses.Add($"{field.Key} = {paramPlaceholder}");
            }
            return this;
        }

        public override (string, Dictionary<string, object>) Build()
        {
            query.Append($"UPDATE {table} SET ");
            query.Append(string.Join(", ", setClauses)).Append(" ");

            BuildWhereClause();

            return (query.ToString().Trim(), parameters);
        }
    }
}
