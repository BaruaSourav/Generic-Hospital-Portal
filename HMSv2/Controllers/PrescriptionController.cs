using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSv2.Models.ViewModel;
using HMSv2.Models.EntityManager;
using HMSv2.Models.DB;


namespace HMSv2.Controllers
{
    public class PrescriptionController : Controller
    {
        HMS_DBEntities db = new HMS_DBEntities();        
        // GET: Prescription
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddDiagnose(int pid)
        {
            ViewBag.Patient = db.PatientTable.Find(pid);
            TempData["id"] = pid;
            ViewBag.AdminBy = new SelectList(db.Physician, "PhysicianID", "FirstName");
            return View();
        }
        [HttpPost]
        public ActionResult AddDiagnose(Prescription p)
        {

            PrescriptionManager pm = new PrescriptionManager();
            pm.AddDiagBill(p,(int)TempData["id"]);
            return RedirectToAction("Index","PatientTable");
            
        }

        public ActionResult AllDiagnosis()
        {
            var DiagnosisList = db.Diagnosis;
            return View(DiagnosisList.ToList());
        }
    }
}