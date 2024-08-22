using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class InsertSaleDac : BaseCommand<CommandResultWithBody<int>>
    {
        public Sale sale { get; set; }

        public override void ExecuteCore()
        {
            var sql = @"
               INSERT INTO flow.sale_kjd (com_code, io_date, io_no, prod_cd, qty, remarks)
               VALUES (@com_code, @io_date, @io_no, @prod_cd, @qty, @remarks)
             ";

            var parameters = new Dictionary<string, object>()
            {
                {"@com_code", sale.Key.COM_CODE },
                {"@io_date", sale.Key.IO_DATE },
                {"@io_no", sale.Key.IO_NO },
                {"@prod_cd", sale.PROD_CO },
                {"@qty", sale.QTY },
                {"@remarks", sale.REMARK }
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);

        }
    }
}
