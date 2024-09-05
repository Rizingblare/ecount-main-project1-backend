using System.Collections.Generic;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductResultDTO
    {
        public List<SelectProductResultDTO> data { get; set; }
        public int totalCount { get; set; }

        public class SelectProductResultDTO
        {
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public double price { get; set; }
        }
    }
}