using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;
using KCN.ViewModels;

using System.Web.Security;
namespace KCN.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _userRepository.GetAllUser()
               .Any(u => u.Username.ToLower() == user
               .Username.ToLower() && u.Password.ToLower() == user.Password.ToLower());

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }
        public ActionResult Logout()
        {
          
             FormsAuthentication.SignOut();
             return RedirectToAction("Index", "Home");
               
        }

    }
}