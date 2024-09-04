using Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductServiceImpl : IProductService
    {
        public ProductResultDTO.SelectProductResultDTO SelectProducts(ProductRequestDTO.SelectProductRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<SelectProductDac, CommandResultWithBody<int>>(new SelectProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToSelectRequestDTO(request);
                });
            pipeLine.Execute();
            return new ProductResultDTO.SelectProductResultDTO();
        }
        public void InsertProducts(string comCode, ProductRequestDTO.InsertProductRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<InsertProductDac, CommandResultWithBody<int>>(new InsertProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToInsertRequestDTO(comCode, request);
                });
            pipeLine.Execute();
        }

        public void UpdateProducts(string comCode, ProductRequestDTO.UpdateProductRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<UpdateProductDac, CommandResultWithBody<int>>(new UpdateProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToUpdateRequestDTO(comCode, request);
                });
            pipeLine.Execute();
        }

        public void DeleteProducts(string comCode, List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<SelectSaleBeforeDeleteProductDac, CommandResultWithBody<int>>(new SelectSaleBeforeDeleteProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = SaleDTOConverter.ToSelectSaleBeforeDeleteProductRequestDTO(comCode, request);
                })
                .Executed((res) =>
                {
                    if (res.Body > 0) throw BaseException.SALE_ALREADY_EXIST;
                });

            pipeLine.Register<DeleteProductDac, CommandResultWithBody<int>>(new DeleteProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToDeleteRequestDTO(comCode, request);
                });
            pipeLine.Execute();
        }
    }
}