using System.Collections.Generic;
using System.Web.Mvc;

namespace Ecount.Kjd.Project.CSharp
{
    [RoutePrefix("api/sale")]
    public class SaleController : Controller
    {
        private readonly ISaleService saleService = new SaleServiceImpl();

        [HttpGet]
        [Route("select")]
        public JsonResult SelectSales(SaleRequestDTO.SelectSaleRequestDTO request)
        {
            try
            {
                CookieHandler.GetOrSetComCode(Request, Response);

                var data = saleService.SelectSales(request);
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
        public JsonResult InsertSales(SaleRequestDTO.InsertSaleRequestDTO request)
        {
            try
            {
                var comCode = CookieHandler.GetOrSetComCode(Request, Response);
                saleService.InsertSales(comCode, request);
                return Json(ApiUtils.Success<object>(null));
            }
            catch (BaseException error)
            {
                return Json(ApiUtils.Error(error));
            }
        }

        [HttpPost]
        [Route("update")]
        public JsonResult UpdateSales(SaleRequestDTO.UpdateSaleRequestDTO request)
        {
            try
            {
                var comCode = CookieHandler.GetOrSetComCode(Request, Response);
                saleService.UpdateSales(comCode, request);
                return Json(ApiUtils.Success<object>(null));
            }
            catch (BaseException error)
            {
                return Json(ApiUtils.Error(error));
            }
        }

        [HttpPost]
        [Route("delete")]
        public JsonResult DeleteSales(List<SaleRequestDTO.DeleteSaleRequestDTO> request)
        {
            try
            {
                var comCode = CookieHandler.GetOrSetComCode(Request, Response);
                saleService.DeleteSales(comCode, request);
                return Json(ApiUtils.Success<object>(null));
            }
            catch (BaseException error)
            {
                return Json(ApiUtils.Error(error));
            }

        }
    }
}