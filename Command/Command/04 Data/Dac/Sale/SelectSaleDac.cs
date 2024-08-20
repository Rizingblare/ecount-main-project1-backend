using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.SelectSaleDac;

namespace Command
{
    public class SelectSaleDac : BaseCommand<SelectSaleDacRequestDto, CommandResultWithBody<List<Sale>>>
    {
        public override void ExecuteCore()
        {
            var sql = @"
                SELECT com_code, io_date, io_no, prod_cd, qty, remarks
                FROM flow.sale_kjd
                WHERE com_code = @com_code AND io_date = @io_date AND io_no = @io_no
            ";

            var parameters = new Dictionary<string, object>()
            {
                {"@com_code", this.Request.ComCode},
                {"@io_date", this.Request.IoDate},
                {"@io_no", this.Request.IoNo}
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Query<Sale>(sql, parameters, (reader, data) =>
            {
                data.Key.COM_CODE = reader["com_code"].ToString();
                data.Key.IO_DATE = reader["io_date"].ToString();
                data.Key.IO_NO = Convert.ToInt32(reader["io_no"]);
                data.PROD_CO = reader["prod_cd"].ToString();
                data.QTY = Convert.ToInt32(reader["qty"]);
                data.REMARK = reader["remarks"].ToString();
            });
        }

        public class SelectSaleDacRequestDto : BaseRequest
        {
            public string ComCode { get; set; }
            public string IoDate { get; set; }
            public int IoNo { get; set; }
        }
    }
}