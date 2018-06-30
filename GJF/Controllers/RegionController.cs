using System.Web.Mvc;
using AutoMapper;
using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using GJF.Domain.Models.Region;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace GJF.Controllers
{
    public class RegionController : BaseController
    {

        private readonly IRegionBll _regionBll;
        
        public ActionResult Index()
        {
            return View();
        }

        public RegionController(IRegionBll regionBll)
        {
            _regionBll = regionBll;
        }

        public JsonResult GetRegions([DataSourceRequest]DataSourceRequest request)
        {
            var datasourceResult = _regionBll.GetAllQueryable().ToDataSourceResult(request, Mapper.Map<RegionViewModel>);
            return Json(datasourceResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddRegion([DataSourceRequest] DataSourceRequest request, Region region)
        {
            if (region != null && ModelState.IsValid)
            {
                _regionBll.Add(region);
            }
            return Json(new[] { region }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult EditRegion([DataSourceRequest] DataSourceRequest request, Region region)
        {
            if (region != null && ModelState.IsValid)
            {
                _regionBll.Update(region);
            }

            return Json(new[] { region }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult DeleteRegion([DataSourceRequest] DataSourceRequest request, Region region)
        {
            if (region != null)
            {
                _regionBll.Delete(region.Id);
            }

            return Json(new[] { region }.ToDataSourceResult(request, ModelState));
        }


    }
}