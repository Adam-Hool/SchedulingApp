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
    public class ShiftsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Shifts
        public ActionResult Index()
        {
            var shift = db.Shift.Include(s => s.employee).Include(s => s.jobRole);
            return View(shift.ToList());
        }

        // GET: Shifts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shift.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // GET: Shifts/Create
        public ActionResult Create()
        {
            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName");
            ViewBag.JobRoleID = new SelectList(db.JobRole, "ID", "JobTitle");
            return View();
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeesID,RegisteredCompanyID,ScheduleID,JobRoleID,AvailabilityID,StartTime,EndTime")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Shift.Add(shift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName", shift.EmployeesID);
            ViewBag.JobRoleID = new SelectList(db.JobRole, "ID", "JobTitle", shift.JobRoleID);
            return View(shift);
        }

        // GET: Shifts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shift.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName", shift.EmployeesID);
            ViewBag.JobRoleID = new SelectList(db.JobRole, "ID", "JobTitle", shift.JobRoleID);
            return View(shift);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeesID,RegisteredCompanyID,ScheduleID,JobRoleID,AvailabilityID,StartTime,EndTime")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeesID = new SelectList(db.Employees, "ID", "FirstName", shift.EmployeesID);
            ViewBag.JobRoleID = new SelectList(db.JobRole, "ID", "JobTitle", shift.JobRoleID);
            return View(shift);
        }

        // GET: Shifts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shift.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shift shift = db.Shift.Find(id);
            db.Shift.Remove(shift);
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
