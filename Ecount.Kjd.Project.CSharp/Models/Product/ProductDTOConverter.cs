using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductDTOConverter
    {
        public static SelectRequestDto ToSelectRequestDTO(ProductRequestDTO.SelectProductRequestDTO request)
        {
            var result = new SelectRequestDto(ProductColumns.TABLE_NAME);
            result.WhereConditions.Add(ConditionDTOConverter.ToLikeConditionDTO(ProductColumns.PROD_CD, request.searchByProdCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToLikeConditionDTO(ProductColumns.PROD_NM, request.searchByProdName));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(ProductColumns.IS_USED, request.searchByIsused));
            if (request.orderByProdCode)
            {
                result.OrderByConditions.Add(OrderByDTOConverter.ToOrderByConditionDTO(ProductColumns.PROD_CD, request.orderByProdCodeASC));
            }
            if (request.orderByProdName)
            {
                result.OrderByConditions.Add(OrderByDTOConverter.ToOrderByConditionDTO(ProductColumns.PROD_NM, request.orderByProdNameASC));
            }
            result.Limit = request.pageSize;
            result.Offset = request.pageSize * request.pageNum;
            return result;
        }
        public static InsertRequestDto ToInsertRequestDTO(string comCode, ProductRequestDTO.InsertProductRequestDTO request)
        {
            var result = new InsertRequestDto(ProductColumns.TABLE_NAME);
            result.FieldValues.Add(ProductColumns.COM_CODE, comCode);
            result.FieldValues.Add(ProductColumns.PROD_CD, request.prodCode);
            result.FieldValues.Add(ProductColumns.PROD_NM, request.prodName);
            result.FieldValues.Add(ProductColumns.PRICE, request.price);
            result.FieldValues.Add(ProductColumns.WRITE_DT, DateTime.Now);
            result.FieldValues.Add(ProductColumns.IS_USED, true);

            return result;
        }

        public static UpdateRequestDto ToUpdateRequestDTO(string comCode, ProductRequestDTO.UpdateProductRequestDTO request)
        {
            var result = new UpdateRequestDto(ProductColumns.TABLE_NAME);
            result.SetFields.Add(ProductColumns.PROD_NM, request.prodName);
            result.SetFields.Add(ProductColumns.PRICE, request.price);
            result.SetFields.Add(ProductColumns.IS_USED, request.isUsed);
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(ProductColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(ProductColumns.PROD_CD, request.prodCode));

            return result;
        }

        public static DeleteRequestDto ToDeleteRequestDTO(string comCode, List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            var prodCodes = request.Select(item => item.prodCode).ToList();
            var result = new DeleteRequestDto(ProductColumns.TABLE_NAME);
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(ProductColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ConditionDTOConverter.ToConditionDTO(ProductColumns.PROD_CD, prodCodes));

            return result;
        }
    }
}