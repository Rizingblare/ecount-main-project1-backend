using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class SaleRequestDTO
    {
        public class SelectSaleRequestDTO
        {

        }

        public class InsertSaleRequestDTO
        {
            public string data_dt { get; set; }
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public int quantity { get; set; }
            public int price { get; set; }
            public string remarks { get; set; }
        }

        public class UpdateSaleRequestDTO
        {
            public string data_dt { get; set; }
            public int data_no { get; set; }
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public int quantity { get; set; }
            public int price { get; set; }
            public string remarks { get; set; }
        }
        public class DeleteSaleRequestDTO
        {
            public string data_dt { get; set; }
            public int data_no { get; set; }
        }
    }
}