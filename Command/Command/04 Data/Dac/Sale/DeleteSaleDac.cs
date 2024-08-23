//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Command.DeleteSaleDac;

//namespace Command
//{
//    public class DeleteSaleDac : BaseCommand<CommandResultWithBody<int>>
//    {
//        public override void ExecuteCore()
//        {
//            var sql = @"
//                DELETE FROM flow.sale_kjd
//                WHERE com_code = @com_code AND io_date = @io_date AND io_no = @io_no
//            ";

//            var parameters = new Dictionary<string, object>()
//            {
//                {"@com_code", this.Request.ComCode},
//                {"@io_date", this.Request.IoDate},
//                {"@io_no", this.Request.IoNo}
//            };

//            var dbManager = new DbManager();
//            this.Result.Body = dbManager.Execute(sql, parameters);
//        }

//        public class DeleteSaleDacRequestDto : BaseRequest
//        {
//            public string ComCode { get; set; }
//            public string IoDate { get; set; }
//            public int IoNo { get; set; }
//        }
//    }
//}