using Command;
using System.Collections.Generic;

namespace Ecount.Kjd.Project.CSharp
{
    public class ConditionDTOConverter
    {
        public static BaseConditionDTO ToConditionDTO(string leftFields, bool rightValue)
        {
            return new BaseConditionDTO
            {
                LeftField = leftFields,
                Value = rightValue,
                Operator = ComparisonOperators.ComparisonOperator.Equal
            };
        }
        public static BaseConditionDTO ToConditionDTO(string leftFields, double rightValue)
        {
            return new BaseConditionDTO
            {
                LeftField = leftFields,
                Value = rightValue,
                Operator = ComparisonOperators.ComparisonOperator.Equal
            };
        }
        public static BaseConditionDTO ToConditionDTO(string leftFields, int rightValue)
        {
            return new BaseConditionDTO
            {
                LeftField = leftFields,
                Value = rightValue,
                Operator = ComparisonOperators.ComparisonOperator.Equal
            };
        }

        public static BaseConditionDTO ToConditionDTO(string leftFields, string rightValue)
        {
            return new BaseConditionDTO
            {
                LeftField = leftFields,
                Value = rightValue,
                Operator = ComparisonOperators.ComparisonOperator.Equal
            };
        }


        public static BaseConditionDTO ToConditionDTO(string leftField, List<string> rightValues)
        {
            return new BaseConditionDTO
            {
                LeftField = leftField,
                Value = rightValues,
                Operator = ComparisonOperators.ComparisonOperator.In,
                IsInCondition = true
            };
        }

        public static LikeConditionDTO ToLikeConditionDTO(string leftFields, string rightValue)
        {
            return new LikeConditionDTO
            {
                LeftField = leftFields,
                Value = rightValue,
                Operator = ComparisonOperators.ComparisonOperator.Like
            };
        }

        public static BaseConditionDTO ToComplexConditionDTO(List<BaseConditionDTO> subConditions, bool isOrCondition = false)
        {
            return new BaseConditionDTO
            {
                IsComplexCondition = true,
                Value = subConditions,
                IsOrCondition = isOrCondition
            };
        }

        public static BetweenConditionDTO ToBetweenConditionDTO(string searchByDateStart, string searchByDateEnd)
        {
            return new BetweenConditionDTO
            {
                LeftField = searchByDateStart,
                Value = searchByDateEnd
            };
        }
    }
}