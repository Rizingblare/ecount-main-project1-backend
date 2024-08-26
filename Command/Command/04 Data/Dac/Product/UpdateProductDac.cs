using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.UpdateProductDac;

namespace Command
{
    public class UpdateProductDac : BaseCommand<UpdateRequestDto, CommandResultWithBody<int>>
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

            // Todo: 변경된 품목이 Sale 테이블에 해당 품목이 존재하면 Cascade
            PipeLine pipe = new PipeLine();
        }
    }
}