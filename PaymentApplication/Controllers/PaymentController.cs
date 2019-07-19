using PayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayApp.Controllers
{
    public class PaymentController : Controller
    {
        //
        // GET: /Payment/

        public ActionResult Index(string Amount)
        {
            List<PaymentMethods> paymodes;

            ViewBag.Message = "Single Place to Recharge your mobile, pay your postpaid bills.";

            // Insert a new user into the database
            using (PaymentContext db = new PaymentContext())
            {
                paymodes = db.PaymentMethods.ToList();
            }

            ViewBag.Amount = Amount;

            return View(paymodes);
        }

        public ActionResult Action(int id, string Amount)
        {
            string RedirectAction = "";

            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == (int)PaymentModes.DebitCard)
                RedirectAction = "DebitCard";
            else if (id == (int)PaymentModes.CreditCard)
                RedirectAction = "CreditCard";
            else if (id == (int)PaymentModes.InternetBanking)
                RedirectAction = "InternetBanking";
            else if (id == (int)PaymentModes.BHIMUPI)
                RedirectAction = "BHIMUPI";
            else
                RedirectAction = "DebitCard";

            TempData["Amount"] = Amount;

            return RedirectToAction(RedirectAction);
        }

        public ActionResult DebitCard()
        {
            var model = new DebitCardModel();

            model.Amount = TempData["Amount"].ToString();

            ViewBag.ExpriryMonth = ExpiryMonths();
            ViewBag.ExpiryYear = ExpiryYears();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DebitCard(DebitCardModel model)
        {
            var result = false;

            //Validate Debit Card Detail through API

            //Call API to Payment 
            result = true;

            if (result)
            {
                return RedirectToAction("PaymentSuccess");
            }

            return View(model);
        }

        public ActionResult CreditCard()
        {
            return View();
        }

        public ActionResult InternetBanking()
        {
            return View();
        }

        public ActionResult BHIMUPI()
        {
            return View();
        }

        public ActionResult PaymentSuccess()
        {
            return View();
        }

        private IEnumerable<SelectListItem> ExpiryMonths()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            list.Add(new SelectListItem() { Text = "Month", Value = "", Selected = true });

            list.Add(new SelectListItem() { Text = "01", Value = "01", Selected = true });
            list.Add(new SelectListItem() { Text = "02", Value = "02", Selected = true });
            list.Add(new SelectListItem() { Text = "03", Value = "03", Selected = true });
            list.Add(new SelectListItem() { Text = "04", Value = "04", Selected = true });
            list.Add(new SelectListItem() { Text = "05", Value = "05", Selected = true });
            list.Add(new SelectListItem() { Text = "06", Value = "06", Selected = true });
            list.Add(new SelectListItem() { Text = "07", Value = "07", Selected = true });
            list.Add(new SelectListItem() { Text = "08", Value = "08", Selected = true });
            list.Add(new SelectListItem() { Text = "09", Value = "09", Selected = true });
            list.Add(new SelectListItem() { Text = "10", Value = "10", Selected = true });
            list.Add(new SelectListItem() { Text = "11", Value = "11", Selected = true });
            list.Add(new SelectListItem() { Text = "12", Value = "12", Selected = true });

            return list;
        }

        private IEnumerable<SelectListItem> ExpiryYears()
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var minYear = DateTime.Now.Year;
            var maxYear = minYear + 25;

            list.Add(new SelectListItem() { Text = "Year", Value = "", Selected = true });

            for (var i = minYear; i <= maxYear; i++)
            {
                var year = i.ToString();
                list.Add(new SelectListItem() { Text = year, Value = year, Selected = true });
            }

            return list;
        }

    }
}
