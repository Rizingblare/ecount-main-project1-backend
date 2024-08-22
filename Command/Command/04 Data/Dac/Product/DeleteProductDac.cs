using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Command.DeleteProductDac;

namespace Command
{
    public class DeleteProductDac : BaseCommand<CommandResultWithBody<int>>
    {
        public override void ExecuteCore()
        {
            var sql = @"
                DELETE FROM flow.product_kjd
                WHERE com_code = @com_code AND prod_cd = @prod_cd
            ";

            var parameters = new Dictionary<string, object>()
            {
                {"@com_code", this.Request.ComCode},
                {"@prod_cd", this.Request.ProdCd}
            };

            var dbManager = new DbManager();
            this.Result.Body = dbManager.Execute(sql, parameters);
        }

        public class DeleteProductDacRequestDto : BaseRequest
        {
            public string ComCode { get; set; }
            public string ProdCd { get; set; }
        }
    }
}