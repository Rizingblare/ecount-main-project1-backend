using System.Collections.Generic;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;

namespace Ecount.Kjd.Project.CSharp
{
    [RoutePrefix("api/sale")]
    public class SaleController : Controller
    {
        private readonly ISaleService saleService = new SaleServiceImpl();

        [HttpGet]
        [Route("select")]
        public JsonResult SelectSales()
        {
            CookieHandler.GetOrSetComCode(Request, Response);

            var data = saleService.SelectSales();
            var response = ApiUtils.Success(data);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("insert")]
        public JsonResult InsertSales(SaleRequestDTO.InsertSaleRequestDTO request)
        {
            var comCode = CookieHandler.GetOrSetComCode(Request, Response);
            saleService.InsertSales(comCode, request);
            return Json(ApiUtils.Success<object>(null));
        }

        [HttpPost]
        [Route("update")]
        public JsonResult UpdateSales(SaleRequestDTO.UpdateSaleRequestDTO request)
        {
            var comCode = CookieHandler.GetOrSetComCode(Request, Response);
            saleService.UpdateSales(comCode, request);
            return Json(ApiUtils.Success<object>(null));
        }

        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteSales(List<SaleRequestDTO.DeleteSaleRequestDTO> request)
        {
            var comCode = CookieHandler.GetOrSetComCode(Request, Response);
            saleService.DeleteSales(comCode, request);
            return Json(ApiUtils.Success<object>(null));
        }
    }
}