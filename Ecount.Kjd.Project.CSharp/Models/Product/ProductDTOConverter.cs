using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Ecount.Kjd.Project.CSharp.Models.Product
{
    public class ProductDTOConverter
    {
        public static InsertRequestDto ToInsertRequestDTO(string comCode, ProductRequestDTO.InsertProductRequestDTO request)
        {
            var result = new InsertRequestDto(ProductColumns.TABLE_NAME);
            result.FieldValues.Add(ProductColumns.COM_CODE, comCode);
            result.FieldValues.Add(ProductColumns.PROD_CD, request.prodCode);
            result.FieldValues.Add(ProductColumns.PROD_NM, request.prodName);
            result.FieldValues.Add(ProductColumns.PRICE, request.price);
            result.FieldValues.Add(ProductColumns.IS_USED, true);

            return result;
        }

        public static UpdateRequestDto ToUpdateRequestDTO(string comCode, ProductRequestDTO.UpdateProductRequestDTO request)
        {
            var result = new UpdateRequestDto(ProductColumns.TABLE_NAME);
            result.SetFields.Add(ProductColumns.PROD_NM, request.prodName);
            result.SetFields.Add(ProductColumns.PRICE, request.price);
            result.SetFields.Add(ProductColumns.IS_USED, request.isUsed);
            result.WhereConditions.Add(ToConditionDTO(ProductColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ToConditionDTO(ProductColumns.PROD_CD, request.prodCode));

            return result;
        }

        public static DeleteRequestDto ToDeleteRequestDTO(string comCode, List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            var prodCodes = request.Select(item => item.prodCode).ToList();
            var result = new DeleteRequestDto(ProductColumns.TABLE_NAME);
            result.WhereConditions.Add(ToConditionDTO(ProductColumns.COM_CODE, comCode));
            result.WhereConditions.Add(ToConditionDTO(ProductColumns.PROD_CD, prodCodes));

            return result;
        }

        public static ConditionDto ToConditionDTO(string leftFields, string rightValue)
        {
            return new ConditionDto
            {
                LeftField = leftFields,
                Value = rightValue,
                Operator = ComparisonOperators.ComparisonOperator.Equal
            };
        }

        public static ConditionDto ToConditionDTO(string leftField, List<string> rightValues)
        {
            return new ConditionDto
            {
                LeftField = leftField,
                Value = rightValues,
                Operator = ComparisonOperators.ComparisonOperator.In,
                IsInCondition = true
            };
        }
    }
}