using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.SelectProductDac;

namespace Command
{
    public class SelectProductDac : BaseCommand<SelectRequestDto, CommandResultWithBody<List<Product>>>
    {
        public override void ExecuteCore()
        {
            SelectQueryBuilder sb = QueryBuilderFactory
                .Select(Request.SelectFields)
                .From(Request.TableName)
                .Where(Request.WhereConditions);

            (var sql, var parameters) = sb.Build();

            var dbManager = new DbManager();
            Result.Body = dbManager.Query<Product>(sql, parameters, (reader, data) =>
            {
                data.Key.COM_CODE = reader["com_code"].ToString();
                data.Key.PROD_CD = reader["prod_cd"].ToString();
                data.PRICE = reader.GetInt16(3);
                data.PROD_NM = reader["prod_nm"].ToString();
                data.WRITE_DT = (DateTime)reader["write_dt"];
            });
        }
    }
}
