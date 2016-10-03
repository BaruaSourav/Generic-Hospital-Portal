using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMSv2.Controllers
{
    public class ManagerController : Controller
    {
        
        public ActionResult Home()
        {

            return RedirectToAction("Index", "PatientTable");
        }
    }
}