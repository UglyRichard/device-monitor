using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRLog.Controllers
{
    public class MonitorController : Controller
    {
        public ActionResult Generator()
        {
            return View();
        }

        public ActionResult Result()
        {
            // load a number of all stored messages and push to view in viewbag
            int count = MonitorApp.CountMessages();
            ViewBag.Count = count.ToString();

            return View();
        }
    }
}