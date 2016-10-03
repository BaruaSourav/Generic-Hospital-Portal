using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HMSv2.Models.DB;
using HMSv2.Models.EntityManager;
using System.Web.Security;

namespace HMSv2.Controllers
{
    public class UserAuthController : Controller
    {
        HMS_DBEntities db = new HMS_DBEntities();
        // GET: UserAuth
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            if(ModelState.IsValid)
            {
                UserManager um = new UserManager();
                string pw = um.GetUserPW(u.Username);

                if (string.IsNullOrEmpty(pw))
                    ModelState.AddModelError("", "The user login name or password is incorrect");
                else
                {
                    if(u.Password.Equals(pw))
                    {
                        FormsAuthentication.SetAuthCookie(u.Username, false);
                        if(um.GetUserRole(u.Username).Equals("Admin"))
                            return RedirectToAction("Home", "Admin");
                        else if (um.GetUserRole(u.Username).Equals("Manager"))
                            return RedirectToAction("Home", "Manager");


                    }
                    else
                    {
                        ModelState.AddModelError("", "The Password provided is incorrect");
                    }
                }
            }
            return View(u);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "Global");
        }

    }
}