using Command;
using System.Collections.Generic;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductServiceImpl : IProductService
    {
        public ProductResultDTO SelectProducts(ProductRequestDTO.SelectProductRequestDTO request)
        {
            var pipeLine = new PipeLine();
            var result = new ProductResultDTO();

            pipeLine.Register<SelectProductCountDac, CommandResultWithBody<int>>(new SelectProductCountDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToSelectCountRequestDTO(request);
                })
                .Executed((res) => pipeLine.Contexts.Add("totalCount", res.Body));

            pipeLine.Register<SelectProductDac, CommandResultWithBody<List<Product>>>(new SelectProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToSelectRequestDTO(request);
                })
                .Executed((res) => result = ProductDTOConverter.ToSelectResultDTO(res.Body, (int)pipeLine.Contexts["totalCount"]));
            pipeLine.Execute();
            return result;
        }
        public void InsertProducts(string comCode, ProductRequestDTO.InsertProductRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<SelectCountBeforeProductDac, CommandResultWithBody<int>>(new SelectCountBeforeProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToSelectCountBeforeProductRequestDTO(comCode, request.prodCode);
                })
                .Executed((res) =>
                {
                    if (res.Body > 0) throw BaseException.PRODUCT_ALREADY_EXIST;
                });
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
            pipeLine.Register<SelectCountBeforeProductDac, CommandResultWithBody<int>>(new SelectCountBeforeProductDac())
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToSelectCountBeforeProductRequestDTO(comCode, request.prodCode);
                })
                .Executed((res) =>
                {
                    if (res.Body == 0) throw BaseException.PRODUCT_NOT_EXIST;
                });

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