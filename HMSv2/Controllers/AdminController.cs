using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HMSv2.Models.DB;
using System.Data.Entity;
using System.Net;
using HMSv2.Models.EntityManager;

namespace HMSv2.Controllers
{
    public class AdminController : Controller
    {
        HMS_DBEntities db = new HMS_DBEntities();
        UserManager um = new UserManager();

        // GET: Admin
        public ActionResult Details(int? id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physician p = db.Physician.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        public ActionResult UserDetails(int? id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User p = db.User.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AddDoctor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDoctor(Physician p)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                db.Physician.Add(p);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            
            return View(p);
        }
        public ActionResult List()
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }
            var d = db.Physician;
            return View(d.ToList());
        }

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(User p)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                db.User.Add(p);
                db.SaveChanges();
                return RedirectToAction("UserList");
            }


            return View(p);
        }
        public ActionResult UserList()
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }
            var d = db.User;
            return View(d.ToList());
        }
        public ActionResult Edit(int? id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physician p = db.Physician.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
           
            return View(p);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Physician p)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }


            if (ModelState.IsValid)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            //ViewBag.District = new SelectList(db.District, "DistrictID", "Name", patientTable.District);
            //ViewBag.InsurancePlan = new SelectList(db.Plan, "PlanID", "PlanName", patientTable.InsurancePlan);
            return View(p);
        }


        public ActionResult UserEdit(int? id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User p = db.User.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(User p)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }


            if (ModelState.IsValid)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            //ViewBag.District = new SelectList(db.District, "DistrictID", "Name", patientTable.District);
            //ViewBag.InsurancePlan = new SelectList(db.Plan, "PlanID", "PlanName", patientTable.InsurancePlan);
            return View(p);
        }


        public ActionResult Delete(int? id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Physician p = db.Physician.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: PatientTable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }
            Physician p = db.Physician.Find(id);
            db.Physician.Remove(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult UserDelete(int? id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User p = db.User.Find(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // POST: PatientTable/Delete/5
        [HttpPost, ActionName("UserDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UserDeleteConfirmed(int id)
        {
            if (um.isLoggedIn())
            {
                if (!um.GetUserRole(User.Identity.Name).Equals("Admin"))
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return HttpNotFound();
            }
            User p = db.User.Find(id);
            db.User.Remove(p);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }



    }
}