using System;

namespace Command
{
    public class SelectProductCountDac : BaseCommand<SelectRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Select(Request.Fields)
                .From(Request.TableName)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = Convert.ToInt32(dbManager.Scalar(sql, parameters));
        }
    }
}
