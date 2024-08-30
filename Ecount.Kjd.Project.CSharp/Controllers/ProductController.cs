using Command;
using Ecount.Kjd.Project.CSharp.Models.Product;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ecount.Kjd.Project.CSharp.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : Controller
    {
        private readonly ProductService productService = new ProductService();

        [HttpGet]
        [Route("select")]
        public JsonResult SelectProducts()
        {
            var data = productService.SelectProducts();
            var response = new ApiUtils<ProductResultDTO.SelectProductResultDTO>()
            {
                Success = true,
                Response = data,
                Error = null
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("insert")]
        public JsonResult InsertProducts(ProductRequestDTO.InsertProductRequestDTO request)
        {
            var data = productService.InsertProducts();
            var response = new ApiUtils<ProductResultDTO.InsertProductResultDTO>()
            {
                Success = true,
                Response = null,
                Error = null
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("update")]
        public JsonResult UpdateProducts(ProductRequestDTO.UpdateProductRequestDTO request)
        {
            var data = productService.UpdateProducts();
            var response = new ApiUtils<ProductResultDTO.UpdateProductResultDTO>()
            {
                Success = true,
                Response = null,
                Error = null
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteProducts(List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            var data = productService.DeleteProducts();
            var response = new ApiUtils<ProductResultDTO.DeleteProductResultDTO>()
            {
                Success = true,
                Response = null,
                Error = null
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}