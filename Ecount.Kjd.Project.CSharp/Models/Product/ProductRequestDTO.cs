using Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductRequestDTO
    {
        public class SelectProductRequestDTO
        {
            public string searchByProdCode { get; set; }
            public string searchByProdName { get; set; }
            public string searchByIsused { get; set; }
            public bool orderByProdCode { get; set; }
            public bool orderByProdCodeASC { get; set; }
            public bool orderByProdName { get; set; }
            public bool orderByProdNameASC { get; set; }
            public int pageNum { get; set; }
            public int pageSize { get; set; }
        }

        public class InsertProductRequestDTO
        {
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public int price { get; set; }
        }

        public class UpdateProductRequestDTO
        {
            public string prodCode { get; set; }
            public string prodName { get; set; }
            public int price { get; set; }
            public bool isUsed { get; set; }
        }
        public class DeleteProductRequestDTO
        {
            public string prodCode { get; set; }
        }
    }
}