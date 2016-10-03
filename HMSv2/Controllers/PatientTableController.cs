using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HMSv2.Models.DB;

namespace HMSv2.Controllers
{
    public class PatientTableController : Controller
    {
        private HMS_DBEntities db = new HMS_DBEntities();

        // GET: PatientTable
        public ActionResult Index()
        {
            var patientTable = db.PatientTable.Include(p => p.District1).Include(p => p.Plan);
            return View(patientTable.ToList());
        }

        // GET: PatientTable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTable patientTable = db.PatientTable.Find(id);
            if (patientTable == null)
            {
                return HttpNotFound();
            }
            return View(patientTable);
        }

        // GET: PatientTable/Create
        public ActionResult Create()
        {
            ViewBag.District = new SelectList(db.District, "DistrictID", "Name");
            ViewBag.InsurancePlan = new SelectList(db.Plan, "PlanID", "PlanName");
            return View();
        }

        // POST: PatientTable/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FirstName,LastName,DOB,Phone,Email,District,InsurancePlan")] PatientTable patientTable)
        {
            if (ModelState.IsValid)
            {
                db.PatientTable.Add(patientTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.District = new SelectList(db.District, "DistrictID", "Name", patientTable.District);
            ViewBag.InsurancePlan = new SelectList(db.Plan, "PlanID", "PlanName", patientTable.InsurancePlan);
            return View(patientTable);
        }

        // GET: PatientTable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTable patientTable = db.PatientTable.Find(id);
            if (patientTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.District = new SelectList(db.District, "DistrictID", "Name", patientTable.District);
            ViewBag.InsurancePlan = new SelectList(db.Plan, "PlanID", "PlanName", patientTable.InsurancePlan);
            return View(patientTable);
        }

        // POST: PatientTable/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,FirstName,LastName,DOB,Phone,Email,District,InsurancePlan")] PatientTable patientTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.District = new SelectList(db.District, "DistrictID", "Name", patientTable.District);
            ViewBag.InsurancePlan = new SelectList(db.Plan, "PlanID", "PlanName", patientTable.InsurancePlan);
            return View(patientTable);
        }

        // GET: PatientTable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientTable patientTable = db.PatientTable.Find(id);
            if (patientTable == null)
            {
                return HttpNotFound();
            }
            return View(patientTable);
        }

        // POST: PatientTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientTable patientTable = db.PatientTable.Find(id);
            db.PatientTable.Remove(patientTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
