using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GJF.Controllers
{
    public class BoardController : BaseController
    {
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ControlPanel()
        {
            return View();
        }
    }
}