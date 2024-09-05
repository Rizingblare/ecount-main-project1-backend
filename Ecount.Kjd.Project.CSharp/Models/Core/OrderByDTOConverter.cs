using Command;

namespace Ecount.Kjd.Project.CSharp
{
    public class OrderByDTOConverter
    {
        public static OrderByConditionDto ToOrderByConditionDTO(string field, bool sortDirection)
        {
            return new OrderByConditionDto
            {
                FieldName = field,
                SortDirection = sortDirection ? "ASC" : "DESC"
            };
        }
    }
}