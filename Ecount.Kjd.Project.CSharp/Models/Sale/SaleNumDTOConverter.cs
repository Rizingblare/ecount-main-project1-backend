using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp.Models.Sale
{
    public class SaleNumDTOConverter
    {
        public static SelectRequestDto ToSelectSaleNumRequestDTO(string comCode, string data_dt)
        {
            var result = new SelectRequestDto(SaleNumColumns.TABLE_NAME);
            result.Fields = new List<string> { SaleNumColumns.IO_NO };
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleNumColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleNumColumns.IO_DATE, data_dt));
            
            return result;
        }

        public static InsertRequestDto ToInsertSaleNumRequestDTO(string comCode, string data_dt)
        {
            var result = new InsertRequestDto(SaleNumColumns.TABLE_NAME);
            result.FieldValues.Add(SaleColumns.COM_CODE, comCode);
            result.FieldValues.Add(SaleColumns.IO_DATE, data_dt);
            result.FieldValues.Add(SaleColumns.IO_NO, 1);

            return result;
        }

        public static UpdateRequestDto ToUpdateSaleNumRequestDTO(string comCode, string data_dt, int nextDateNo)
        {
            var result = new UpdateRequestDto(SaleNumColumns.TABLE_NAME);
            result.SetFields.Add(SaleNumColumns.IO_NO, nextDateNo);
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleNumColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleNumColumns.IO_DATE, data_dt));

            return result;
        }
    }
}