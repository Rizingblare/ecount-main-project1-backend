using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.UpdateProductDac;

namespace Command
{
    public class UpdateProductDac : BaseCommand<UpdateProductDacRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            var sql = @"
                UPDATE flow.product_kjd
                SET prod_nm = @prod_nm, 
                    price = @price, 
                    write_dt = @write_dt
                WHERE com_code = @com_code 
                  AND prod_cd = @prod_cd
            ";

            var parameters = new Dictionary<string, object>()
            {
                {"@com_code", this.Request.ComCode},
                {"@prod_cd", this.Request.ProdCd},
                {"@prod_nm", this.Request.ProdNm},
                {"@price", this.Request.Price},
                {"@write_dt", this.Request.WriteDt}
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }

        public class UpdateProductDacRequestDto : BaseRequest
        {
            public string ComCode { get; set; }
            public string ProdCd { get; set; }
            public string ProdNm { get; set; }
            public int Price { get; set; }
            public DateTime WriteDt { get; set; }
        }
    }
}