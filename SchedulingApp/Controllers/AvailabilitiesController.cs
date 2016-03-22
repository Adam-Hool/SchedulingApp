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
    public class AvailabilitiesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Availabilities
        public ActionResult Index()
        {
            var availability = db.Availability.Include(a => a.Employee);
            return View(availability.ToList());
        }

        // GET: Availabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = db.Availability.Find(id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            return View(availability);
        }

        // GET: Availabilities/Create
        public ActionResult Create()
        {
            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName");
            return View();
        }

        // POST: Availabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeesID,RegisteredCompanyID,ScheduleID,JobRoleID,ShiftID,MondayAvailability,TuesdayAvailability,WednesdayAvailability,ThursdayAvailability,FridayAvailability,SaturdayAvailability,SundayAvailability")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                db.Availability.Add(availability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName", availability.EmployeesID);
            return View(availability);
        }

        // GET: Availabilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = db.Availability.Find(id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName", availability.EmployeesID);
            return View(availability);
        }

        // POST: Availabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeesID,RegisteredCompanyID,ScheduleID,JobRoleID,ShiftID,MondayAvailability,TuesdayAvailability,WednesdayAvailability,ThursdayAvailability,FridayAvailability,SaturdayAvailability,SundayAvailability")] Availability availability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(availability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName", availability.EmployeesID);
            return View(availability);
        }

        // GET: Availabilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Availability availability = db.Availability.Find(id);
            if (availability == null)
            {
                return HttpNotFound();
            }
            return View(availability);
        }

        // POST: Availabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Availability availability = db.Availability.Find(id);
            db.Availability.Remove(availability);
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
