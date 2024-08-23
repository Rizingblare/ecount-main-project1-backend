using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class InsertQueryBuilder : BaseQueryBuilder<InsertQueryBuilder>
    {
        private List<string> columns = new List<string>();
        private List<string> values = new List<string>();
        private string table;

        public InsertQueryBuilder Insert(string table)
        {
            this.table = table;
            return this;
        }

        public InsertQueryBuilder Into(Dictionary<string, object> fieldValues)
        {
            foreach (var field in fieldValues)
            {
                columns.Add(field.Key);
                values.Add(AddParameter(field.Value));
            }
            return this;
        }

        public override (string, Dictionary<string, object>) Build()
        {
            query.Append($"INSERT INTO {table} ({string.Join(", ", columns)}) ");
            query.Append($"VALUES ({string.Join(", ", values)}) ");
            return (query.ToString().Trim(), parameters);
        }
    }


}
