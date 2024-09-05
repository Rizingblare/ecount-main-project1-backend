using System;

namespace Command
{
    public class ProductKey : IEntityKey
    {
        public string COM_CODE { get; set; }
        public string PROD_CD { get; set; }
    }
    public class Product : BaseEntity<ProductKey>
    {
        public string PROD_NM { get; set; }
        public double PRICE { get; set; }
        public DateTime WRITE_DT { get; set; }
        public bool IS_USED { get; set; }
    }
}
