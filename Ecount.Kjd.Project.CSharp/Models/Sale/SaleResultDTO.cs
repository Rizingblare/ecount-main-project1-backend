using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp.Models.Product
{
    public class SaleResultDTO
    {
        public List<SelectSaleResult> Data { get; set; }
    }
    public class SelectSaleResult
    {
        [JsonProperty("data_dt")]
        public string DataDt { get; set; }
        [JsonProperty("data_no")]
        public int DataNo { get; set; }
        [JsonProperty("prodCode")]
        public string ProdCode { get; set; }
        [JsonProperty("prodName")]
        public string ProdName { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("remarks")]
        public string Remarks { get; set; }
    }
}