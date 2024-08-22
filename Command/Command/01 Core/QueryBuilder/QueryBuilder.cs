using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class QueryBuilder
    {
        private BaseQueryBuilder _queryBuilder;

        // SELECT 명령어 시작
        public SelectQueryBuilder Select(List<string> fields = null)
        {
            _queryBuilder = new SelectQueryBuilder().Select(fields);
            return (SelectQueryBuilder)_queryBuilder;
        }

        // INSERT 명령어 시작
        public InsertQueryBuilder InsertInto(string table, List<string> columns)
        {
            _queryBuilder = new InsertQueryBuilder().Into(table).Columns(columns);
            return (InsertQueryBuilder)_queryBuilder;
        }

        // UPDATE 명령어 시작
        public UpdateQueryBuilder Update(string table)
        {
            _queryBuilder = new UpdateQueryBuilder().Update(table);
            return (UpdateQueryBuilder)_queryBuilder;
        }

        // DELETE 명령어 시작
        public DeleteQueryBuilder DeleteFrom(string table)
        {
            _queryBuilder = new DeleteQueryBuilder().From(table);
            return (DeleteQueryBuilder)_queryBuilder;
        }

        // 파라미터 목록 반환 (예: NpgsqlParameter를 생성하기 위한 기초 데이터)
        public Dictionary<string, object> GetParameters()
        {
            return _queryBuilder?.GetParameters();
        }

        // 최종적으로 쿼리 문자열 반환
        public string Build()
        {
            return _queryBuilder?.GenerateQuery() ?? string.Empty;
        }
    }


}
