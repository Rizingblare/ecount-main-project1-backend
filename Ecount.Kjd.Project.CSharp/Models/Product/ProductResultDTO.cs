using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductResultDTO
    {
        public List<SelectProductResultDTO> data { get; set; }

        public class SelectProductResultDTO
        {
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public int price { get; set; }
        }
    }
}