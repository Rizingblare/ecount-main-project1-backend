using Command;
using Ecount.Kjd.Project.CSharp.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecount.Kjd.Project.CSharp
{
    public class ProductServiceImpl : IProductService
    {
        public ProductResultDTO.SelectProductResultDTO SelectProducts()
        {
            throw new NotImplementedException();
        }
        public void InsertProducts(string comCode, ProductRequestDTO.InsertProductRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<InsertProductDac, CommandResultWithBody<int>>(new InsertProductDac())
                .AddFilter((cmd) => true)
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToInsertRequestDTO(comCode, request);
                })
                .Executed((res) => Console.WriteLine($"{res.Body}개 처리 완료됨."));
            pipeLine.Execute();
        }

        public void UpdateProducts(string comCode, ProductRequestDTO.UpdateProductRequestDTO request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<UpdateProductDac, CommandResultWithBody<int>>(new UpdateProductDac())
                .AddFilter((cmd) => true)
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToUpdateRequestDTO(comCode, request);
                })
                .Executed((res) => Console.WriteLine($"{res.Body}개 처리 완료됨."));
            pipeLine.Execute();
        }

        public void DeleteProducts(string comCode, List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            var pipeLine = new PipeLine();
            pipeLine.Register<DeleteProductDac, CommandResultWithBody<int>>(new DeleteProductDac())
                .AddFilter((cmd) => true)
                .Mapping((cmd) =>
                {
                    cmd.Request = ProductDTOConverter.ToDeleteRequestDTO(comCode, request);
                })
                .Executed((res) => Console.WriteLine($"{res.Body}개 처리 완료됨."));
            pipeLine.Execute();
        }
    }
}