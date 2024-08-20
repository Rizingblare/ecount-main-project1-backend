using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class InsertProductDac : BaseCommand<BaseRequest, CommandResultWithBody<int>>
    {
        public Product product { get; set; }

        public override void ExecuteCore()
        {
            var sql = @"
                INSERT INTO flow.product_kjd (com_code, prod_cd, prod_nm, price, write_dt)
                VALUES (@com_code, @prod_cd, @prod_nm, @price, @write_dt)
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@com_code", product.Key.COM_CODE },
                { "@prod_cd", product.Key.PROD_CD },
                { "@prod_nm", product.PROD_NM },
                { "@price", product.PRICE },
                { "@write_dt", product.WRITE_DT }
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
            //parameters.Add("@com_code", "80000");

        }
    }
}
