using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using GJF.BLL.Helpers.Security;
using GJF.Domain.Entities;
using GJF.Domain.Models.User;

namespace GJF.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ISignInManager _signInManager;
        private IAuthenticationManager _authenticationManager => System.Web.HttpContext.Current.GetOwinContext().Authentication;

        public AccountController(ISignInManager signInManager)
        {
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[ActionLogFilter]
        public ActionResult Login(LoginViewModel model/*, string returnUrl*/)
        {
            if (ModelState.IsValid)
            {
                User user;
                if (_signInManager.LogIn(model.UserName, model.Password, out user))
                {
                    _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    Response.Cookies.Clear();


                    var identity = IdentityConfig.CreateClaimsIdentity(user);

                    _authenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe

                    }, identity);

                    return RedirectToAction("Index", "Home");
                }
            }


            ModelState.AddModelError("", "მომხმარებელის სახელი ან პაროლი.");
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[NoCache]
        //[ActionLogFilter]
        public ActionResult LogOff()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            Response.Cookies.Clear();

            return RedirectToAction("Login", "Account");
        }


        [Authorize]
        public ActionResult ChangePassword()
        {
            var model = new ChangePasswordModel();
            return View(model);
        }

        [HttpPost]
        [Authorize]
        //[ActionLogFilter]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (_signInManager.ChangePassword(model, User.Identity.Name))
                {
                    _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    Response.Cookies.Clear();

                    return RedirectToAction("LogIn", "Account");
                }

                ModelState.AddModelError(string.Empty, "ძველი პაროლი არასწორია ან ახალი პაროლები არ ემთხვევა !");
                return View();
            }

            ModelState.AddModelError(string.Empty, "სავალდებულო ველები არ არის შევსებული !");
            return View();
        }
    }
}