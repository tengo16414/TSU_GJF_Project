using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using GJF.BLL.Abstract;
using GJF.Domain.Models.User;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace GJF.Controllers
{
    //[Authorize(Roles = Roles.Admin)]
    public class UserController : BaseController
    {
        private readonly IUserBll _userBll;
        public UserController(IUserBll userBll)
        {
            _userBll = userBll;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers([DataSourceRequest]DataSourceRequest request)
        {
            var datasourceResult = _userBll.GetAllQueryable(u => u.UserRoles.Select(p => p.Role)).ToDataSourceResult(request, Mapper.Map<UserViewModel>);
            return SerializeAsJson(datasourceResult);
        }

        
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserEditModel userEditModel)
        {
            userEditModel.PasswordHash = "123456";
            if (ModelState.IsValid)
            {
                var id = _userBll.AddUser(userEditModel);
                return View("~/Views/Shared/_Success.cshtml");
            }
            return View();
        }


        
        public ActionResult EditUser(string id)
        {
            var user = Mapper.Map<UserEditModel>(_userBll.GetSingle(u => u.Id == id, u => u.UserRoles.Select(r => r.Role)));
            return View(user);
        }


        [HttpPost]
        public ActionResult EditUser(UserEditModel userEditModel)
        {
            if (ModelState.IsValid)
            {
                var id = _userBll.UpdateUser(userEditModel);
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _userBll.DeleteUser(id);
                }
                return Json("");

            }
            catch (System.Exception)
            {
                throw new System.Exception();
            }

        }


        public ActionResult ResetPassword(string id)
        {
            var result = _userBll.ResetPassword(id);
            return Json(new { status = "Success", message = "Success" }, JsonRequestBehavior.AllowGet);
        }

    }
}