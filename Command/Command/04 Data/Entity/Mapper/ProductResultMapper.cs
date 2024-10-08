﻿using System;
using System.Data.Common;

namespace Command
{
    public static class ProductResultMapper
    {
        public static void Map(DbDataReader reader, Product data)
        {
            data.Key.COM_CODE = reader[ProductColumns.COM_CODE].ToString();
            data.Key.PROD_CD = reader[ProductColumns.PROD_CD].ToString();
            data.PRICE = reader.GetDouble(reader.GetOrdinal(ProductColumns.PRICE));
            data.PROD_NM = reader[ProductColumns.PROD_NM].ToString();
            data.WRITE_DT = (DateTime)reader[ProductColumns.WRITE_DT];
            data.IS_USED = (bool)reader[ProductColumns.IS_USED];
        }
    }
}
