using System.Collections.Generic;

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
