using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GJF.BLL.Abstract;

namespace GJF.Controllers
{
    public class DropDownController : Controller
    {
        
        private IRoleBll _roleBll;
        private IRegionBll _regionBll;
        private ISportsmanBll _sportsmanBll;
     

        public DropDownController(IRoleBll roleBll, IRegionBll regionBll, ISportsmanBll sportsmanBll)
        {
            _roleBll = roleBll;
            _regionBll = regionBll;
            _sportsmanBll = sportsmanBll;
        }

        public JsonResult GetRoles()
        {
            var datasourceResult = _roleBll.GetAll();
            var result = datasourceResult.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRegions()
        {
            var datasourceResult = _regionBll.GetAll();
            var result = datasourceResult.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSportsman()
        {
            var datasourceResult = _sportsmanBll.GetAll();
            var result = datasourceResult.Select(x => new SelectListItem { Text = x.Name +" " + x.Surname, Value = x.Id.ToString() });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}