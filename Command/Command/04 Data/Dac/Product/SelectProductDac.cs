using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.SelectProductDac;

namespace Command
{
    public class SelectProductDac : BaseCommand<SelectProductDacRequestDto, CommandResultWithBody<List<Product>>>
    {
        public override void ExecuteCore()
        {
            var sql = @"
                SELECT *
                FROM flow.product_kjd
                WHERE com_code = @com_code and prod_cd = @prod_cd
            ";

            var parameters = new Dictionary<string, object>()
            {
                {"@com_code", this.Request.ComCode},
                {"@prod_cd", this.Request.ProdCd}
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Query<Product>(sql, parameters, (reader, data) =>
            {
                data.Key.COM_CODE = this.Request.ComCode;
                data.Key.PROD_CD = this.Request.ProdCd;
                data.PRICE = reader.GetInt16(3);
                data.PROD_NM = reader["prod_nm"].ToString();
                data.WRITE_DT = (DateTime)reader["write_dt"];
            });

        }

        public class SelectProductDacRequestDto : BaseRequest
        {
            public string ComCode { get; set; }
            public string ProdCd { get; set; }
        }
    }
}
