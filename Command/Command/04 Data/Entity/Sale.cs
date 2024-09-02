using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SaleKey : IEntityKey
    {
        public string COM_CODE { get; set; }
        public string IO_DATE { get; set; }
        public int IO_NO { get; set; }

    }
    public class Sale : BaseEntity<SaleKey>
    {
        public string PROD_CD {  get; set; }
        public string PROD_NM {  get; set; }
        public int PRICE {  get; set; }
        public int QTY { get; set; }
        public string REMARK { get; set; }
    }
}
