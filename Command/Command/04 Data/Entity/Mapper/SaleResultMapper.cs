using System;
using System.Data.Common;

namespace Command
{
    public static class SaleResultMapper
    {
        public static void Map(DbDataReader reader, Sale data)
        {
            data.Key.COM_CODE = reader[SaleColumns.COM_CODE].ToString();
            data.Key.IO_DATE = reader[SaleColumns.IO_DATE].ToString();
            data.Key.IO_NO = Convert.ToInt32(reader[SaleColumns.IO_NO]);
            data.PROD_CD = reader[SaleColumns.PROD_CD].ToString();
            data.PROD_NM = reader[SaleColumns.PROD_NM].ToString();
            data.PRICE = Convert.ToDouble(reader[SaleColumns.PRICE]);
            data.QTY = Convert.ToDouble(reader[SaleColumns.QTY]);
            data.REMARK = reader[SaleColumns.REMARKS].ToString();
        }
    }
}
