using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public static class QueryBuilderFactory
    {
        public static SelectQueryBuilder Select(List<string> fields = null)
        {
            return new SelectQueryBuilder().Select(fields);
        }

        public static InsertQueryBuilder Insert(string table)
        {
            return new InsertQueryBuilder().Insert(table);
        }

        public static UpdateQueryBuilder Update(string table)
        {
            return new UpdateQueryBuilder().Update(table);
        }

        public static DeleteQueryBuilder Delete(string table)
        {
            return new DeleteQueryBuilder().Delete(table);
        }
    }
}
