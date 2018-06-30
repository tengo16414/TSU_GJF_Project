using AutoMapper;
using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using GJF.Domain.Models.Sportsman;
using GJF.Domain.Models.TournamentSportsman;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJF.Controllers
{
    public class TournamentSportsmanController : BaseController
    {
        private readonly ITournamentSportsmanBll _tournamentSportsmanBll;
        private readonly ITournamentBll _tournamentBll;
        private readonly ISportsmanBll _sportsmanBll;
        private readonly IWrestleBll _wrestleBll;
        private readonly ITournamentWrestleBll _tournamentWrestleBll;


        // GET: TournamentSportsman
        public ActionResult Index(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public TournamentSportsmanController(ISportsmanBll sportsmanBll, ITournamentBll tournamentBll,ITournamentSportsmanBll tournamentSportsmanBll, IWrestleBll wrestleBll, ITournamentWrestleBll tournamentWrestleBll)
        {
            _sportsmanBll = sportsmanBll;
            _tournamentBll = tournamentBll;
            _tournamentSportsmanBll = tournamentSportsmanBll;
            _wrestleBll = wrestleBll;
            _tournamentWrestleBll = tournamentWrestleBll;
        }

        public JsonResult GetAllSportsman([DataSourceRequest]DataSourceRequest request, int id)
        {
            var dataSourceResult = _tournamentSportsmanBll.GetRawsQueryable(ts => ts.TournamentId == id, x => x.Sportsman, x => x.Sportsman.Region).ToList().ToDataSourceResult(request, Mapper.Map<TournamentSportsman>);
            return Json(dataSourceResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create(int Id)
        {
            var tournament = _tournamentBll.GetSingle(t => t.Id == Id);
            var tournamentSportsmenCount = _tournamentSportsmanBll.GetRawsQueryable(ts => ts.TournamentId == Id).ToList().Count();
            if (tournamentSportsmenCount < tournament.NumberOfContestants)
            {
                var tournamentSportsmanEditModel = new TournamentSportsmanEditModel();
                tournamentSportsmanEditModel.TournamentId = Id;
                return View(tournamentSportsmanEditModel);
            }
            return View("~/Views/Shared/Error.cshtml");
        }

        [HttpPost]
        public ActionResult Create(TournamentSportsmanEditModel tournamentSportsmanEditModel)
        {
            if (ModelState.IsValid)
            {
                var tournamentSportsman = new TournamentSportsman();
                tournamentSportsman.TournamentId = tournamentSportsmanEditModel.TournamentId;
                tournamentSportsman.SportsmanId = tournamentSportsmanEditModel.SportsmanId;
                tournamentSportsman.Seeded = tournamentSportsmanEditModel.Seeded;
               
                var id = _tournamentSportsmanBll.Add(tournamentSportsman);

                return RedirectToAction("Index", new { id = tournamentSportsman.TournamentId});
            }

            return View();
        }

        public ActionResult Generate(int id)
        {
            var tournamentSportsmen = _tournamentSportsmanBll.GetRawsQueryable(ts => ts.TournamentId == id, x => x.Sportsman);
            var sportsMen  = tournamentSportsmen.Select(x => x.Sportsman).ToList();

            for(int i=0; i<sportsMen.Count; i+=2)
            {
                var wrestle = new Wrestle();
                wrestle.SportsmanOneId = sportsMen.ElementAt(i).Id;
                wrestle.SportsmanTwoId = sportsMen.ElementAt(i + 1).Id;
                wrestle.SporstmanOneIppon = false;
                wrestle.SporstmanTwoIppon = false;
                wrestle.SporstmanOneWazariPoint = 0;
                wrestle.SporstmanTwoWazariPoint = 0;
                wrestle.SportmanOneFine = 0;
                wrestle.SportmanTwoFine = 0;

                var wrestleId =_wrestleBll.Add(wrestle);

                var tournamentWrestle = new TournamentWrestle();
                tournamentWrestle.TournamentId = id;
                tournamentWrestle.WrestleId = (int) wrestleId;
                _tournamentWrestleBll.Add(tournamentWrestle);

            }


            return RedirectToAction("Index", "TournamentWrestle", new { id = id });
          
        }
    }
}