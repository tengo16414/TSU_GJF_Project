using AutoMapper;
using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using GJF.Domain.Models.Tournament;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJF.Controllers
{
    public class TournamentController : BaseController
    {
        private readonly ITournamentBll _tournamentBll;
        

        public ActionResult Index()
        {
            return View();
        }

        public TournamentController(ITournamentBll tournamentBll)
        {
            _tournamentBll = tournamentBll;
        }

        public JsonResult GetTournaments([DataSourceRequest]DataSourceRequest request)
        {
            var datasourceResult = _tournamentBll.GetAllQueryable().ToDataSourceResult(request, Mapper.Map<TournamentViewModel>);
            return Json(datasourceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TournamentEditModel tournamentEditModel)
        {
            if (ModelState.IsValid)
            {
                var tournament = new Tournament();
                tournament.Name = tournamentEditModel.Name;
                tournament.Description = tournamentEditModel.Description;
                tournament.NumberOfContestants = tournamentEditModel.NumberOfContestants;
                tournament.Date = tournamentEditModel.Date;
                tournament.Wrestles = tournamentEditModel.Wrestles;

                var id = _tournamentBll.Add(tournament);

                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            var user = Mapper.Map<TournamentEditModel>(_tournamentBll.GetSingle(u => u.Id == id));
            return View(user);
        }


        [HttpPost]
        public ActionResult Edit(TournamentEditModel tournamentEditModel)
        {
            if (ModelState.IsValid)
            {
                var tournament = new Tournament();
                tournament.Name = tournamentEditModel.Name;
                tournament.Description = tournamentEditModel.Description;
                tournament.NumberOfContestants = tournamentEditModel.NumberOfContestants;
                tournament.Date = tournamentEditModel.Date;
                tournament.Wrestles = tournamentEditModel.Wrestles;

                var id = _tournamentBll.Update(tournament);

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