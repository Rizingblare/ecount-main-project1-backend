using Command;
using System.Collections.Generic;
using System.Linq;

namespace Ecount.Kjd.Project.CSharp
{
    public class SaleDTOConverter
    {
        public static SelectRequestDto ToSelectRequestDTO(SaleRequestDTO.SelectSaleRequestDTO request)
        {
            var result = new SelectRequestDto(SaleColumns.TABLE_NAME);
            if (request.searchByDateStart != null && request.searchByDateEnd != null)
            {
                result.WhereConditions.Add(ConditionDTOConverter.ToBetweenConditionDTO(request.searchByDateStart, request.searchByDateEnd));
            }

            if (request.searchByProdCode != null)
            {
                result.WhereConditions.Add(ConditionDTOConverter.ToLikeConditionDTO(SaleColumns.PROD_CD, request.searchByProdCode));
            }

            if (request.orderByDate)
            {
                result.OrderByConditions.Add(OrderByDTOConverter.ToOrderByConditionDTO(SaleColumns.IO_DATE, request.orderByDateASC));
            }

            if (request.orderByProdCode)
            {
                result.OrderByConditions.Add(OrderByDTOConverter.ToOrderByConditionDTO(SaleColumns.PROD_CD, request.orderByProdCodeASC));
            }

            result.Limit = request.pageSize;
            result.Offset = request.pageSize * request.pageNum;

            return result;
        }

        public static SelectRequestDto ToSelectCountRequestDTO(SaleRequestDTO.SelectSaleRequestDTO request)
        {
            var result = new SelectRequestDto(SaleColumns.TABLE_NAME);
            result.Fields = new List<string> { "COUNT(1)" };
            if (request.searchByDateStart != null && request.searchByDateEnd != null)
            {
                result.WhereConditions.Add(ConditionDTOConverter.ToBetweenConditionDTO(request.searchByDateStart, request.searchByDateEnd));
            }

            if (request.searchByProdCode != null)
            {
                result.WhereConditions.Add(ConditionDTOConverter.ToLikeConditionDTO(SaleColumns.PROD_CD, request.searchByProdCode));
            }
            return result;
        }

        public static SaleResultDTO ToSelectResultDTO(List<Sale> res, int totalCount)
        {
            var result = new SaleResultDTO();
            result.totalCount = totalCount;
            result.data = new List<SaleResultDTO.SelectSaleResultDTO>();
            foreach (var r in res)
            {
                var item = new SaleResultDTO.SelectSaleResultDTO();
                item.data_dt = r.Key.IO_DATE;
                item.data_no = r.Key.IO_NO;
                item.prodCode = r.PROD_CD;
                item.prodName = r.PROD_NM;
                item.quantity = r.QTY;
                item.price = r.PRICE;
                item.remarks = r.REMARK;
                result.data.Add(item);
            }
            return result;
        }
        public static SelectRequestDto ToSelectCountBeforeSaleRequestDTO(string comCode, string data_dt, int data_no)
        {
            var result = new SelectRequestDto(SaleColumns.TABLE_NAME);
            result.Fields = new List<string> { "COUNT(1)" };
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.IO_DATE, data_dt));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(SaleColumns.IO_NO, data_no));
            return result;
        }

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