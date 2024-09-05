using System.Collections.Generic;

namespace Command
{
    public class SelectSaleDac : BaseCommand<SelectRequestDto, CommandResultWithBody<List<Sale>>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Select(Request.Fields)
                .From(Request.TableName)
                .Where(Request.WhereConditions)
                .OrderBy(Request.OrderByConditions)
                .Limit(Request.Limit)
                .Offset(Request.Offset)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Query<Sale>(sql, parameters, SaleResultMapper.Map);
        }
    }
}