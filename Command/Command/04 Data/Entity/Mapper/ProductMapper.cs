using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public static class ProductMapper
    {
        public static void Map(DbDataReader reader, Product data)
        {
            data.Key.COM_CODE = reader[ProductColumns.COM_CODE].ToString();
            data.Key.PROD_CD = reader[ProductColumns.PROD_CD].ToString();
            data.PRICE = reader.GetInt16(reader.GetOrdinal(ProductColumns.PRICE));
            data.PROD_NM = reader[ProductColumns.PROD_NM].ToString();
            data.WRITE_DT = (DateTime)reader[ProductColumns.WRITE_DT];
        }
    }
}
