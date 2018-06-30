using AutoMapper;
using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJF.Controllers
{
    public class TournamentWrestleController : BaseController
    {
        private readonly ITournamentWrestleBll _tournamentWrestleBll;

        // GET: TournamentWrestle
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public TournamentWrestleController(ITournamentWrestleBll tournamentWrestleBll)
        {
            _tournamentWrestleBll = tournamentWrestleBll;
        }

        public JsonResult GetAllWrestles([DataSourceRequest]DataSourceRequest request, int id)
        {
            var dataSourceResult = _tournamentWrestleBll.GetRawsQueryable(ts => ts.TournamentId == id, x => x.Wrestle, x => x.Wrestle.SportsmanOne, x => x.Wrestle.SportsmanTwo).ToList().ToDataSourceResult(request, Mapper.Map<TournamentWrestle>);
            return Json(dataSourceResult, JsonRequestBehavior.AllowGet);
        }
    }
}