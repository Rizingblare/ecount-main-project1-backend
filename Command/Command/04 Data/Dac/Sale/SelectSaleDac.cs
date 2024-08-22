using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.SelectSaleDac;

namespace Command
{
    public class SelectSaleDac : BaseCommand<CommandResultWithBody<List<Sale>>>
    {
        public override void ExecuteCore()
        {
            var parameters = new Dictionary<string, object>();
            var optionalSortString = MakeOptionalSortString(this.Request);

            var sql = $@"
                SELECT com_code, io_date, io_no, prod_cd, qty, remarks
                FROM flow.sale_kjd
                ORDER BY {optionalSortString}io_date, io_no DESC
            ";

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

        private string MakeOptionalSortString(SelectSaleDacRequestDto request)
        {
            StringBuilder sb = new StringBuilder();
            if (request.isOptionalProdCdAes)
            {
                sb.Append("prod_cd, ");
            }

            if (request.isOptionalQtyDesc)
            {
                sb.Append("qty, ");
            }
            return sb.ToString();
        }

        public class SelectSaleDacRequestDto : BaseRequest
        {
            public bool isOptionalProdCdAes { get; set; }
            public bool isOptionalQtyDesc { get; set; }
        }
    }
}