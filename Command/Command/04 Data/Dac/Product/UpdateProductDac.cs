using System;

namespace Command
{
    public class UpdateProductDac : BaseCommand<UpdateRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            ValidateUpdateProduct();

            (var sql, var parameters) = QueryBuilderFactory
                .Update(Request.TableName)
                .Set(Request.SetFields)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }

        private void ValidateUpdateProduct()
        {
            if (Request.SetFields.ContainsKey(ProductColumns.PROD_CD)
                || Request.SetFields.ContainsKey(ProductColumns.COM_CODE))
            {
                throw new InvalidOperationException();
            }
        }
    }
}