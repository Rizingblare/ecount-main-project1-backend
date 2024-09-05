namespace Command
{
    public class SelectSaleNumDac : BaseCommand<SelectRequestDto, CommandResultWithBody<int?>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Select(Request.Fields)
                .From(Request.TableName)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Scalar(sql, parameters) as int?;
        }
    }
}
