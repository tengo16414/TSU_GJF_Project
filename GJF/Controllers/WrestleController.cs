using AutoMapper;
using GJF.BLL.Abstract;
using GJF.Domain.Models.Wrestle;
using System.Web.Mvc;

namespace GJF.Controllers
{
    public class WrestleController : BaseController
    {
        private readonly IWrestleBll _wrestleBll;

        public WrestleController(IWrestleBll wrestleBll)
        {
            _wrestleBll = wrestleBll;
        }

        public ActionResult Index(int id)
        {
            var wrestle = Mapper.Map<WrestleEditModel>(_wrestleBll.GetSingle(u => u.Id == id, w => w.SportsmanOne, w=> w.SportsmanTwo, w=>w.SportsmanOne.Region, w=>w.SportsmanTwo.Region));
            return View(wrestle);
        }

        public ActionResult Control(int id)
        {
            var wrestle = Mapper.Map<WrestleEditModel>(_wrestleBll.GetSingle(wr => wr.Id == id, x=>x.SportsmanOne, x=>x.SportsmanTwo, x=>x.SportsmanOne.Region, x=>x.SportsmanTwo.Region));
            return View(wrestle);
        }
        
    }
}