using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class SaleDTOConverter
    {
        public static InsertRequestDto ToInsertRequestDTO(string comCode, int nextDateNo, SaleRequestDTO.InsertSaleRequestDTO request)
        {
            var result = new InsertRequestDto(SaleColumns.TABLE_NAME);
            result.FieldValues.Add(SaleColumns.COM_CODE, comCode);
            result.FieldValues.Add(SaleColumns.IO_DATE, request.data_dt);
            result.FieldValues.Add(SaleColumns.IO_NO, nextDateNo);
            result.FieldValues.Add(SaleColumns.PROD_CD, request.prodCode);
            result.FieldValues.Add(SaleColumns.PROD_NM, request.prodName);
            result.FieldValues.Add(SaleColumns.QTY, request.quantity);
            result.FieldValues.Add(SaleColumns.PRICE, request.price);
            result.FieldValues.Add(SaleColumns.REMARKS, request.remarks ?? "");

            return result;
        }

        public static UpdateRequestDto ToUpdateRequestDTO(string comCode, SaleRequestDTO.UpdateSaleRequestDTO request)
        {
            var result = new UpdateRequestDto(SaleColumns.TABLE_NAME);
            result.SetFields.Add(SaleColumns.PROD_CD, request.prodCode);
            result.SetFields.Add(SaleColumns.PROD_NM, request.prodName);
            result.SetFields.Add(SaleColumns.QTY, request.quantity);
            result.SetFields.Add(SaleColumns.PRICE, request.price);
            result.SetFields.Add(SaleColumns.REMARKS, request.remarks);
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.IO_DATE, request.data_dt));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.IO_NO, request.data_no));

            return result;
        }
        public static SelectRequestDto ToSelectSaleBeforeDeleteProductRequestDTO(string comCode, List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            var prodCodes = request.Select(item => item.prodCode).ToList();
            var result = new SelectRequestDto(SaleColumns.TABLE_NAME);
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.PROD_CD, prodCodes));
            result.Fields = new List<string> { "COUNT(1)" };
            return result;
        }

        public static DeleteRequestDto ToDeleteRequestDTO(string comCode, List<SaleRequestDTO.DeleteSaleRequestDTO> request)
        {
            var result = new DeleteRequestDto(SaleColumns.TABLE_NAME);

            // ComCode 조건 추가
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.COM_CODE, comCode));

            // 복합 조건 (IO_DATE와 IO_NO 조합) 처리
            var orConditions = new List<BaseConditionDTO>();
            foreach (var saleRequest in request)
            {
                var subConditions = new List<BaseConditionDTO>
                {
                    ConditionDTOConverter.ToConditionDTO(SaleColumns.IO_DATE, saleRequest.data_dt),
                    ConditionDTOConverter.ToConditionDTO(SaleColumns.IO_NO, saleRequest.data_no)
                };
                orConditions.Add(ConditionDTOConverter.ToComplexConditionDTO(subConditions));
            }

            result.WhereConditions.Add(ConditionDTOConverter.ToComplexConditionDTO(orConditions, true)); // OR로 연결

            return result;
        }
    }
}