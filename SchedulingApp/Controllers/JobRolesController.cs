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
    public class JobRolesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: JobRoles
        public ActionResult Index()
        {
            return View(db.JobRole.ToList());
        }

        // GET: JobRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRole jobRole = db.JobRole.Find(id);
            if (jobRole == null)
            {
                return HttpNotFound();
            }
            return View(jobRole);
        }

        // GET: JobRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RegisteredCompaniesId,JobTitle")] JobRole jobRole)
        {
            if (ModelState.IsValid)
            {
                db.JobRole.Add(jobRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobRole);
        }

        // GET: JobRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRole jobRole = db.JobRole.Find(id);
            if (jobRole == null)
            {
                return HttpNotFound();
            }
            return View(jobRole);
        }

        // POST: JobRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RegisteredCompaniesId,JobTitle")] JobRole jobRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobRole);
        }

        // GET: JobRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRole jobRole = db.JobRole.Find(id);
            if (jobRole == null)
            {
                return HttpNotFound();
            }
            return View(jobRole);
        }

        // POST: JobRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobRole jobRole = db.JobRole.Find(id);
            db.JobRole.Remove(jobRole);
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
