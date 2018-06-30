using GJF.BLL.Abstract;
using GJF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GJF.Controllers
{
    public class ValidatorController : BaseController
    {
        private IUserBll _userBll;
        private IRegionBll _regionBll;
        private ISportsmanBll _sportsmanBll;
        public ValidatorController(IUserBll userBll, IRegionBll regionBll, ISportsmanBll sportsmanBll)
        {
            _userBll = userBll;
            _regionBll = regionBll;
            _sportsmanBll = sportsmanBll;
        }


        public JsonResult IsValidUserName(string UserName, string Id)
        {
            UserName = UserName.ToLower();

            //on user create
            if (string.IsNullOrEmpty(Id))
            {
                var user = _userBll.GetUsersQueryable().FirstOrDefault(u => u.UserName == UserName);
                if (user != null)
                    return Json("მომხმარებელი აღნიშნული სახელით უკვე არსებობს", JsonRequestBehavior.AllowGet);
                else
                    return Json(true, JsonRequestBehavior.AllowGet);
            }


            //on user edit
            var result1 = _userBll.GetUsersQueryable().Any(u => u.UserName == UserName && u.Id == Id);
            if (result1)
                return Json(true, JsonRequestBehavior.AllowGet);
            var result2 = _userBll.GetUsersQueryable().Any(u => u.UserName == UserName && u.Id != Id);
            if (result2)
                return Json("მომხმარებელი აღნიშნული სახელით უკვე არსებობს", JsonRequestBehavior.AllowGet);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsValidRegion(string Name, int Id)
        {
            var region = _regionBll.GetSingle(e => e.Name == Name);

            //on region create
            if (Id == 0)
            {
                if (region == null)
                    return Json(true, JsonRequestBehavior.AllowGet);
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }

            //on region edit
            if (Id > 0 && region != null)
            {
                if (Id == region.Id && Name == region.Name)
                    return Json(true, JsonRequestBehavior.AllowGet);
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}