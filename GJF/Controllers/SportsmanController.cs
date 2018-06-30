using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using GJF.BLL.Abstract;
using GJF.Domain.Models.Region;
using GJF.Domain.Models.Sportsman;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using GJF.Domain.Entities;

namespace GJF.Controllers
{
    public class SportsmanController : BaseController
    {
       
        public ActionResult Index()
        {
            return View();
        }

        private readonly ISportsmanBll _sportsmanBll;
        
        public SportsmanController(ISportsmanBll sportsmanBll)
        {
            _sportsmanBll = sportsmanBll;
        }

        public JsonResult GetAllSportsmen([DataSourceRequest]DataSourceRequest request)
        {
            var datasourceResult = _sportsmanBll.GetAllQueryable(sp => sp.Region).ToDataSourceResult(request, Mapper.Map<SportsmanViewModel>);
            return Json(datasourceResult, JsonRequestBehavior.AllowGet);
        }

        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SportsmanEditModel sportsmanEditModel)
        {
            if (ModelState.IsValid)
            {
                var sportsman = new Sportsman();
                sportsman.Name = sportsmanEditModel.Name;
                sportsman.Surname = sportsmanEditModel.Surname;
                sportsman.RegionId = sportsmanEditModel.RegionId;
                sportsman.Rank = sportsmanEditModel.Rank;

                var id = _sportsmanBll.Add(sportsman);

                return RedirectToAction("Index");
            }

            return View();
        }

       
        public ActionResult Edit(int id)
        {
            var user = Mapper.Map<SportsmanEditModel>(_sportsmanBll.GetSingle(u => u.Id == id));
            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(SportsmanEditModel sportsmanEditModel)
        {
            if (ModelState.IsValid)
            {
                var sportsman = new Sportsman();
                sportsman.Name = sportsmanEditModel.Name;
                sportsman.Surname = sportsmanEditModel.Surname;
                sportsman.RegionId = sportsmanEditModel.RegionId;
                sportsman.Rank = sportsmanEditModel.Rank;

                var id = _sportsmanBll.Update(sportsman);

                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {


            return Json("");

        }

    }
}