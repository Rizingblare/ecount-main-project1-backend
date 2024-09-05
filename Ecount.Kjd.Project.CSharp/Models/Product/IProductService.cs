using System.Collections.Generic;

namespace Ecount.Kjd.Project.CSharp
{
    public interface IProductService
    {
        ProductResultDTO SelectProducts(ProductRequestDTO.SelectProductRequestDTO request);
        void InsertProducts(string comCode, ProductRequestDTO.InsertProductRequestDTO request);
        void UpdateProducts(string comCode, ProductRequestDTO.UpdateProductRequestDTO request);
        void DeleteProducts(string comCode, List<ProductRequestDTO.DeleteProductRequestDTO> request);
    }
}
