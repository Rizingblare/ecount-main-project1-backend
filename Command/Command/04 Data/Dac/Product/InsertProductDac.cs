using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class InsertProductDac : BaseCommand<InsertRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Insert(Request.TableName)
                .Into(Request.fieldValues)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }
    }
}
