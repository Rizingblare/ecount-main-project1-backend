using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class UpdateProductDac : BaseCommand<>
    {
        public override void ExecuteCore()
        {
            var sql = @"
                UPDATE flow.product_kjd
                SET (@target_columns) = (@target_values)
                WHERE com_code = @com_code and prod_cd = @prod_cd
            ";

            var parameters = new Dictionary<string, object>()
            {
                {"@com_code", this.Request.ComCode},
                {"@prod_cd", this.Request.ProdCd},
                {"@target_columns", this.Request.ComCode},
                {"@target_values", this.Request.ComCode},
            };
        }
    }

    public class UpdateProductDacRequestDto : BaseRequest
    {
        public string ComCode { get; set; }
        public string ProdCd { get; set; }
        public string targetColumns { get; set; }
        public string targetValues { get; set; }
    }
}
