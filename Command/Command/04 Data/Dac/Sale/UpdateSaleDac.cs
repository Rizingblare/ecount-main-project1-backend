using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.UpdateSaleDac;

namespace Command
{
    public class UpdateSaleDac : BaseCommand<UpdateSaleDacRequestDto, CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            var sql = @"
                UPDATE flow.sale_kjd
                SET prod_cd = @prod_cd, qty = @qty, remarks = @remarks
                WHERE com_code = @com_code AND io_date = @io_date AND io_no = @io_no
            ";

            var parameters = new Dictionary<string, object>()
            {
                {"@com_code", this.Request.ComCode},
                {"@io_date", this.Request.IoDate},
                {"@io_no", this.Request.IoNo},
                {"@prod_cd", this.Request.ProdCd},
                {"@qty", this.Request.Qty},
                {"@remarks", this.Request.Remarks}
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }

        public class UpdateSaleDacRequestDto : BaseRequest
        {
            public string ComCode { get; set; }
            public string IoDate { get; set; }
            public int IoNo { get; set; }
            public string ProdCd { get; set; }
            public int Qty { get; set; }
            public string Remarks { get; set; }
        }
    }
}