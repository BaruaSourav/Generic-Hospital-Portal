using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMSv2.Controllers
{
    public class GlobalController : Controller
    {
        // GET: Global
        public ActionResult Home()
        {
            return View();
        }
    }
}