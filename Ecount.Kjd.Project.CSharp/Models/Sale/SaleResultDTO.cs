using System.Collections.Generic;

namespace Ecount.Kjd.Project.CSharp
{
    public class SaleResultDTO
    {
        public List<SelectSaleResultDTO> data { get; set; }
        public int totalCount { get; set; }

        public class SelectSaleResultDTO
        {
            public string data_dt { get; set; }
            public int data_no { get; set; }
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public double quantity { get; set; }
            public double price { get; set; }
            public string remarks { get; set; }
        }
    }
}