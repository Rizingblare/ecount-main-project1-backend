using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.SelectSaleDac;

namespace Command
{
    public class SelectSaleDac : BaseCommand<SelectRequestDto, CommandResultWithBody<List<Sale>>>
    {
        public override void ExecuteCore()
        {
            (var sql, var parameters) = QueryBuilderFactory
                .Select(Request.Fields)
                .From(Request.TableName)
                .Where(Request.WhereConditions)
                .Build();

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Query<Sale>(sql, parameters, SaleMapper.Map);
        }
    }
}