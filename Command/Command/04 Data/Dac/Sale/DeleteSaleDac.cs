namespace Command
{
    public class DeleteSaleDac : BaseCommand<DeleteRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Delete(Request.TableName)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }
    }
}