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
            // TODO: Sale 테이블에 해당 품목코드를 사용하고 있으면 예외 처리 (유효성 검사)
            //ValidateDeleteProduct();

            (var sql, var parameters) = QueryBuilderFactory
                .Delete(Request.TableName)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }

        private void ValidateDeleteProduct()
        {
            // TODO: Sale 테이블에 해당 품목코드를 사용하고 있으면 예외 처리 (유효성 검사)
            PipeLine pipe = new PipeLine();
            pipe.Register<SelectSaleDac, CommandResultWithBody<Sale>>(new SelectSaleDac());
            throw new NotImplementedException();
        }
    }
}