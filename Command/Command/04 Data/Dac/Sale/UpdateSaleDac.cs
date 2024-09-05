namespace Command
{
    public class UpdateSaleDac : BaseCommand<UpdateRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Update(Request.TableName)
                .Set(Request.SetFields)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }
    }
}