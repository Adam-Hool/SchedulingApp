using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchedulingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace SchedulingApp.Controllers
{
    public class HomeController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Requests()
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

        private List<Events> GetEvents()
        {

            List<Events> eventList = new List<Events>();
            List<Events> currentCompanyList = new List<Events>();
            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user.RegisteredCompany != null)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    eventList = db.Events.ToList();
                    foreach (Events i in eventList)
                    {
                        if (i.RegisteredCompanyid == user.RegisteredCompany)
                        {
                            currentCompanyList.Add(new Events
                            {
                                id = i.id,
                                title = i.title,
                                start = i.start,
                                end = i.end,
                                allDay = i.allDay
                            });

                        }
                    }
                }
            }         
               return currentCompanyList;
        }


        private static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
    }
