using MTERoads.Models.EntityManager;
using MTERoads.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTERoads.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginModel user)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(user.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (user.Password.Equals(password))
                    {
                        //FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                        Session["UserID"] = user.LoginName.ToString();
                        return RedirectToAction("Welcome");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(user);
        }

        public ActionResult Welcome()
        {
            return View();
        }
    }
}