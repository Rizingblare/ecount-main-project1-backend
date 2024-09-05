namespace Ecount.Kjd.Project.CSharp
{
    public class SaleRequestDTO
    {
        public class SelectSaleRequestDTO
        {
            public string searchByDateStart { get; set; }
            public string searchByDateEnd { get; set; }
            public string searchByProdCode { get; set; }
            public bool orderByDate { get; set; }
            public bool orderByDateASC { get; set; }
            public bool orderByProdCode { get; set; }
            public bool orderByProdCodeASC { get; set; }
            public int pageNum { get; set; }
            public int pageSize { get; set; }
        }

        public class InsertSaleRequestDTO
        {
            public string data_dt { get; set; }
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public double quantity { get; set; }
            public double price { get; set; }
            public string remarks { get; set; } = "";
        }

        public class UpdateSaleRequestDTO
        {
            public string data_dt { get; set; }
            public int data_no { get; set; }
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public double quantity { get; set; }
            public double price { get; set; }
            public string remarks { get; set; } = "";
        }
        public class DeleteSaleRequestDTO
        {
            public string data_dt { get; set; }
            public int data_no { get; set; }
        }
    }
}