using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecount.Kjd.Project.CSharp
{
    public interface IProductService
    {
        ProductResultDTO.SelectProductResultDTO SelectProducts();
        void InsertProducts(string comCode, ProductRequestDTO.InsertProductRequestDTO request);
        void UpdateProducts(string comCode, ProductRequestDTO.UpdateProductRequestDTO request);
        void DeleteProducts(string comCode, List<ProductRequestDTO.DeleteProductRequestDTO> request);
    }
}
