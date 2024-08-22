using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.ComparisonOperators;

namespace Command
{
    public abstract class BaseQueryBuilder<T> where T : BaseQueryBuilder<T>
    {
        protected StringBuilder query;
        protected List<string> whereConditions = new List<string>();
        protected Dictionary<string, object> parameters = new Dictionary<string, object>();
        private int parameterIndex = 0;

        public BaseQueryBuilder()
        {
            query = new StringBuilder();
        }

        public T Where(string fieldName, object fieldValue, ComparisonOperator comparisonOperator = ComparisonOperator.Equal)
        {
            // 딕셔너리를 통해 비교 연산자를 SQL 연산자로 변환
            string operatorString = ComparisonOperatorConverter.ToSqlOperator(comparisonOperator);

            // 파라미터 이름 자동 생성
            var paramPlaceholder = $"@param{parameterIndex++}";

            // 조건문 생성 (예: "price > @param1")
            whereConditions.Add($"{fieldName} {operatorString} {paramPlaceholder}");

            // 파라미터 값 매핑
            parameters[paramPlaceholder] = fieldValue;

            return (T)this;
        }

        protected void BuildWhereClause()
        {
            if (whereConditions.Any())
            {
                query.Append("WHERE ");
                query.Append(string.Join(" AND ", whereConditions)).Append(" ");
            }
        }

        // 파라미터 반환
        public Dictionary<string, object> GetParameters()
        {
            return parameters;
        }

        // 쿼리 생성 메서드 - 클라이언트에 직접 노출되지 않음
        public abstract string GenerateQuery();
    }


}
