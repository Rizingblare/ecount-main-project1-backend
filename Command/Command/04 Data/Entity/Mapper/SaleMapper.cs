using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public static class SaleMapper
    {
        public static void Map(DbDataReader reader, Sale data)
        {
            data.Key.COM_CODE = reader[SaleColumns.COM_CODE].ToString();
            data.Key.IO_DATE = reader[SaleColumns.IO_DATE].ToString();
            data.Key.IO_NO = Convert.ToInt32(reader[SaleColumns.IO_NO]);
            data.PROD_CD = reader[SaleColumns.PROD_CD].ToString();
            data.QTY = Convert.ToInt32(reader[SaleColumns.QTY]);
            data.REMARK = reader[SaleColumns.REMARKS].ToString();
        }
    }
}
