using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.DeleteProductDac;

namespace Command
{
    public class DeleteProductDac : BaseCommand<DeleteRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            // Todo: Sale 테이블에 해당 품목이 존재하는지 확인 후 존재하면 예외 처리
            PipeLine pipe = new PipeLine();

            (var sql, var parameters) = QueryBuilderFactory
                .Delete(Request.TableName)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }
    }
}