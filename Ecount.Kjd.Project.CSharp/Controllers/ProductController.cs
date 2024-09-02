using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Ecount.Kjd.Project.CSharp
{
    [RoutePrefix("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService productService = new ProductServiceImpl();

        [HttpGet]
        [Route("select")]
        public JsonResult SelectProducts()
        {
            CookieHandler.GetOrSetComCode(Request, Response);

            var data = productService.SelectProducts();
            var response = ApiUtils.Success(data);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("insert")]
        public JsonResult InsertProducts(ProductRequestDTO.InsertProductRequestDTO request)
        {
            var comCode = CookieHandler.GetOrSetComCode(Request, Response);
            productService.InsertProducts(comCode, request);
            return Json(ApiUtils.Success<object>(null));
        }

        [HttpPost]
        [Route("update")]
        public JsonResult UpdateProducts(ProductRequestDTO.UpdateProductRequestDTO request)
        {
            var comCode = CookieHandler.GetOrSetComCode(Request, Response);
            productService.UpdateProducts(comCode, request);
            return Json(ApiUtils.Success<object>(null));
        }

        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteProducts(List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            var comCode = CookieHandler.GetOrSetComCode(Request, Response);
            productService.DeleteProducts(comCode, request);
            return Json(ApiUtils.Success<object>(null));
        }
    }
}