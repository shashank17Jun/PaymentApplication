using PayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Services> services;

            ViewBag.Message = "Single Place to Recharge your mobile, pay your postpaid bills.";

            // Insert a new user into the database
            using (ServicesContext db = new ServicesContext())
            {
                services = db.PaymentServices.ToList();
            }

            return View(services);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
