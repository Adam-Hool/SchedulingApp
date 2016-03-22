using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchedulingApp.Models;

namespace SchedulingApp.Controllers
{
    public class RegisteredCompaniesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: RegisteredCompanies
        public ActionResult Index()
        {
            return View(db.RegisteredCompanies.ToList());
        }

        // GET: RegisteredCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredCompanies registeredCompanies = db.RegisteredCompanies.Find(id);
            if (registeredCompanies == null)
            {
                return HttpNotFound();
            }
            return View(registeredCompanies);
        }

        // GET: RegisteredCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisteredCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeesID,ScheduleID,JobRoleID,ShiftID,AvailabilityID,CompanyName")] RegisteredCompanies registeredCompanies)
        {
            if (ModelState.IsValid)
            {
                db.RegisteredCompanies.Add(registeredCompanies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registeredCompanies);
        }

        // GET: RegisteredCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredCompanies registeredCompanies = db.RegisteredCompanies.Find(id);
            if (registeredCompanies == null)
            {
                return HttpNotFound();
            }
            return View(registeredCompanies);
        }

        // POST: RegisteredCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeesID,ScheduleID,JobRoleID,ShiftID,AvailabilityID,CompanyName")] RegisteredCompanies registeredCompanies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeredCompanies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registeredCompanies);
        }

        // GET: RegisteredCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredCompanies registeredCompanies = db.RegisteredCompanies.Find(id);
            if (registeredCompanies == null)
            {
                return HttpNotFound();
            }
            return View(registeredCompanies);
        }

        // POST: RegisteredCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredCompanies registeredCompanies = db.RegisteredCompanies.Find(id);
            db.RegisteredCompanies.Remove(registeredCompanies);
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
