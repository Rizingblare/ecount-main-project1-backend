using System.Collections.Generic;

namespace Command
{
    public class InsertRequestDto : BaseRequest
    {
        public string TableName { get; set; }
        public Dictionary<string, object> FieldValues { get; set; } = new Dictionary<string, object>();

        public InsertRequestDto(string tableName)
        {
            TableName = tableName;
        }
    }
}
