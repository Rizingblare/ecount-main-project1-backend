using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class InsertProductDac : BaseCommand<CommandResultWithBody<int>>
    {
        public Product Entity { get; set; }

        public override void ExecuteCore()
        {
            var sql = @"
                INSERT INTO flow.product_kjd (com_code, prod_cd, prod_nm, price, write_dt)
                VALUES (@com_code, @prod_cd, @prod_nm, @price, @write_dt)
            ";

            var parameters = new Dictionary<string, object>()
            {
                { "@com_code", Entity.Key.COM_CODE },
                { "@prod_cd", Entity.Key.PROD_CD },
                { "@prod_nm", Entity.PROD_NM },
                { "@price", Entity.PRICE },
                { "@write_dt", Entity.WRITE_DT }
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
            //parameters.Add("@com_code", "80000");

        }
    }
}
