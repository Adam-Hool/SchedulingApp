using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchedulingApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchedulingApp.Controllers
{
    public class RequestsController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: Requests
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requests requests = db.Requests.Find(id);
            if (requests == null)
            {
                return HttpNotFound();
            }
            return View(requests);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,date,start,end,url,allDay,RegisteredCompany")] Requests requests)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(requests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requests);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requests requests = db.Requests.Find(id);
            if (requests == null)
            {
                return HttpNotFound();
            }
            return View(requests);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,date,start,end,url,allDay,RegisteredCompany")] Requests requests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requests);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Requests requests = db.Requests.Find(id);
            if (requests == null)
            {
                return HttpNotFound();
            }
            return View(requests);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Requests requests = db.Requests.Find(id);
            db.Requests.Remove(requests);
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
        //calendar implimentation
        public ActionResult GetEvents(double start, double end)
        {
            var fromDate = ConvertFromUnixTimestamp(start);
            var toDate = ConvertFromUnixTimestamp(end);

            //Get the events
            //You may get from the repository also
            var eventList = GetEvents();

            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
        //public List<Events> MakeEvent([Bind(Include = "id,title,date,start,end,url,allDay")] Events events)
        //{
        //    List<Events> eventList = new List<Events>();
        //    if (ModelState.IsValid)
        //    {
        //        db.Events.Add(events);
        //        db.SaveChanges();
        //    }
        //    eventList.Add(newEvent);
        //    return eventList;
        //}
        //public JsonResult GetEvents()
        //{
        //    using (var db = new DataBaseContext())
        //    {
        //        var events = from cevent in db.Events
        //                     select cevent;
        //        var rows = events.ToList().Select(cevent => new {
        //            id = cevent.id,
        //            start = cevent.start.ToString(),
        //            end = cevent.end.ToString()
        //        }).ToArray();
        //        return Json(rows, JsonRequestBehavior.AllowGet);
        //    }
        //}



        private List<Requests> GetEvents()//[Bind(Include = "id,title,date,start,end,url,allDay")] Events events)
        {
            List<Requests> eventList = new List<Requests>();
            List<Requests> currentCompanyList = new List<Requests>();
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user.RegisteredCompany != null)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    eventList = db.Requests.ToList();
                    foreach (Requests i in eventList)
                    {
                        var CompaniesEvent = from currentCompany in db.Requests
                                             where currentCompany.RegisteredCompany == user.RegisteredCompany
                                             select currentCompany;
                        currentCompanyList.AddRange(CompaniesEvent);
                    }
                }
            }
            //int eventListSize = eventList.Count;
            //for (int i = 0; i < eventListSize; i++)
            //{
            //    //eventList[i];
            //    Events newEvent = new Events
            //    {
            //        id = eventList[i].id,
            //        title = eventList[i].title,
            //        start = eventList[i].start,
            //        end = eventList[i].end,
            //        allDay = eventList[i].allDay
            //    };


            //    eventList.Add(newEvent);

            //    //    //newEvent = new Events
            //    //    //{
            //    //    //    id = 1,
            //    //    //    title = "Event 3",
            //    //    //    start = DateTime.Now.AddDays(2).ToString("s"),
            //    //    //    end = DateTime.Now.AddDays(3).ToString("s"),
            //    //    //    allDay = false
            //    //    //};

            //    //    //eventList.Add(newEvent);
            //}
            return currentCompanyList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
