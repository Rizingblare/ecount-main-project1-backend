namespace Command
{
    public class InsertSaleNumDac : BaseCommand<InsertRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Insert(Request.TableName)
                .Into(Request.FieldValues)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }
    }
}
