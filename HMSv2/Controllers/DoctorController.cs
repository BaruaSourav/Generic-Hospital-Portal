using HMSv2.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace HMSv2.Controllers
{
    public class DoctorController : Controller
    {
        HMS_DBEntities db = new HMS_DBEntities();
        // GET: Patient
        public ActionResult Index(string searchString)
        {
            //string searchString = id;

            var patientTable = db.PatientTable.Include(p => p.District1).Include(p => p.Plan);
            if (!String.IsNullOrEmpty(searchString))
            {
                patientTable = patientTable.Where(s => s.FirstName.Contains(searchString));
            }
            return View(patientTable.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            PatientTable patientTable = db.PatientTable.Find(id);
            if (patientTable == null)
            {
                return HttpNotFound();
            }
            return View(patientTable);
        }

    }
}