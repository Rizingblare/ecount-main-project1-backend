using System.Collections.Generic;
using System.Web.Mvc;

namespace Ecount.Kjd.Project.CSharp
{
    [RoutePrefix("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService productService = new ProductServiceImpl();

        [HttpGet]
        [Route("select")]
        public JsonResult SelectProducts(ProductRequestDTO.SelectProductRequestDTO request)
        {
            try
            {
                CookieHandler.GetOrSetComCode(Request, Response);
                var data = productService.SelectProducts(request);
                var response = ApiUtils.Success(data);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (BaseException error)
            {
                return Json(ApiUtils.Error(error));
            }
        }

        [HttpPost]
        [Route("insert")]
        public JsonResult InsertProducts(ProductRequestDTO.InsertProductRequestDTO request)
        {
            try
            {
                var comCode = CookieHandler.GetOrSetComCode(Request, Response);
                productService.InsertProducts(comCode, request);
                return Json(ApiUtils.Success<object>(null));
            }
            catch (BaseException error)
            {
                return Json(ApiUtils.Error(error));
            }
        }

        [HttpPost]
        [Route("update")]
        public JsonResult UpdateProducts(ProductRequestDTO.UpdateProductRequestDTO request)
        {
            try
            {
                var comCode = CookieHandler.GetOrSetComCode(Request, Response);
                productService.UpdateProducts(comCode, request);
                return Json(ApiUtils.Success<object>(null));
            }
            catch (BaseException error)
            {
                return Json(ApiUtils.Error(error));
            }
        }

        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteProducts(List<ProductRequestDTO.DeleteProductRequestDTO> request)
        {
            try
            {
                var comCode = CookieHandler.GetOrSetComCode(Request, Response);
                productService.DeleteProducts(comCode, request);
                return Json(ApiUtils.Success<object>(null));
            }
            catch (BaseException error)
            {
                return Json(ApiUtils.Error(error));
            }
        }
    }
}