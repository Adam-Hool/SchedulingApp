using SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulingApp.Controllers
{
    public class HomeController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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



        private List<Events> GetEvents()//[Bind(Include = "id,title,date,start,end,url,allDay")] Events events)
        {
            List<Events> eventList = new List<Events>();
            using (DataBaseContext db = new DataBaseContext())
            {
                eventList = db.Events.ToList();
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
            return eventList;
        }

        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
