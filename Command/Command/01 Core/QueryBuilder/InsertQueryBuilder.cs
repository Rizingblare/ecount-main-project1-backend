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

        public InsertQueryBuilder Into(string table)
        {
            this.table = table;
            return this;
        }

        public InsertQueryBuilder Columns(List<string> columns)
        {
            this.columns.AddRange(columns);
            return this;
        }

        public InsertQueryBuilder Values(List<string> values)
        {
            this.values.AddRange(values);
            return this;
        }

        public override string GenerateQuery()
        {
            query.Append($"INSERT INTO {table} ({string.Join(", ", columns)}) ");
            query.Append($"VALUES ({string.Join(", ", values)}) ");
            return query.ToString().Trim();
        }
    }


}
