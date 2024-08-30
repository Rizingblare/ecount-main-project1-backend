using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductResultDTO
    {
        public List<SelectProductResultDTO> Data { get; set; }

        public class SelectProductResultDTO
        {
            [JsonProperty("prodCode")]
            public string ProdCode { get; set; }
            [JsonProperty("prodName")]
            public string ProdName { get; set; }
            [JsonProperty("price")]
            public int Price { get; set; }
        }
    }
}