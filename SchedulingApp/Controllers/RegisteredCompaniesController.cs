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
    [Authorize(Roles ="GodAdmin")]
    public class RegisteredCompaniesController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: RegisteredCompanies
        public ActionResult Index()
        {
            return View(db.RegisteredCompanies.ToList());
        }

        // GET: RegisteredCompanies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredCompany registeredCompany = db.RegisteredCompanies.Find(id);
            if (registeredCompany == null)
            {
                return HttpNotFound();
            }
            return View(registeredCompany);
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
        public ActionResult Create([Bind(Include = "id,CompanyName")] RegisteredCompany registeredCompany)
        {
            if (ModelState.IsValid)
            {
                db.RegisteredCompanies.Add(registeredCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registeredCompany);
        }

        // GET: RegisteredCompanies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredCompany registeredCompany = db.RegisteredCompanies.Find(id);
            if (registeredCompany == null)
            {
                return HttpNotFound();
            }
            return View(registeredCompany);
        }

        // POST: RegisteredCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,CompanyName")] RegisteredCompany registeredCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registeredCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registeredCompany);
        }

        // GET: RegisteredCompanies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredCompany registeredCompany = db.RegisteredCompanies.Find(id);
            if (registeredCompany == null)
            {
                return HttpNotFound();
            }
            return View(registeredCompany);
        }

        // POST: RegisteredCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RegisteredCompany registeredCompany = db.RegisteredCompanies.Find(id);
            db.RegisteredCompanies.Remove(registeredCompany);
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
