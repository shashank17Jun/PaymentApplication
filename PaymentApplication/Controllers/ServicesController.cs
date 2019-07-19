using PayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayApp.Controllers
{
    public class ServicesController : Controller
    {
        //
        // GET: /Services/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Action(int id)
        {
            string RedirectAction = "";

            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (id == (int)ServiceCodes.MobileRecharge)
                RedirectAction = "MobileRecharge";
            else if (id == (int)ServiceCodes.DTHRecharge)
                RedirectAction = "DTHRecharge";
            else if (id == (int)ServiceCodes.Electricity)
                RedirectAction = "Electricity";
            else if (id == (int)ServiceCodes.CreditCard)
                RedirectAction = "CreditCard";
            else if (id == (int)ServiceCodes.PostPaid)
                RedirectAction = "PostPaid";
            else if (id == (int)ServiceCodes.Landline)
                RedirectAction = "Landline";
            else if (id == (int)ServiceCodes.Broadband)
                RedirectAction = "Broadband";
            else if (id == (int)ServiceCodes.Gas)
                RedirectAction = "Gas";
            else if (id == (int)ServiceCodes.Water)
                RedirectAction = "Water";
            else if (id == (int)ServiceCodes.Datacard)
                RedirectAction = "Datacard";
            else if (id == (int)ServiceCodes.Insurance)
                RedirectAction = "Insurance";
            else if (id == (int)ServiceCodes.MunicipalTax)
                RedirectAction = "MunicipalTax";
            else
                RedirectAction = "MobileRecharge";

            return RedirectToAction(RedirectAction);
        }

        public ActionResult MobileRecharge()
        {
            ServicesContext db = new ServicesContext();

            var model = new MobileRechargeModel();

            IEnumerable<SelectListItem> MobileCircles = db.MobileCircleList.Select(x => new SelectListItem() { Value = x.MobileCircle, Text = x.MobileCircle });
            IEnumerable<SelectListItem> MobileOperators = db.MobileOperatorList.Select(x => new SelectListItem() { Value = x.OperatorName, Text = x.OperatorName });            

            ViewBag.MobileCircle = MobileCircles;
            ViewBag.MobileOperator = MobileOperators;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MobileRecharge(MobileRechargeModel model)
        {
            TempData["model"] = model;
            return RedirectToAction("MobileRechargePreview");
        }

        public ActionResult MobileRechargePreview()
        {
            var Modal = (MobileRechargeModel)TempData["model"];
            return View(Modal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MobileRechargePreview(MobileRechargeModel model)
        {
            var Amount = model.Amount;
            return RedirectToAction("Index", "Payment", Amount);
        }

        public ActionResult DTHRecharge()
        {

            return View();
        }

        public ActionResult Electricity()
        {

            return View();
        }

        public ActionResult CreditCard()
        {

            return View();
        }

        public ActionResult PostPaid()
        {

            return View();
        }

        public ActionResult Landline()
        {

            return View();
        }

        public ActionResult Broadband()
        {

            return View();
        }

        public ActionResult Gas()
        {

            return View();
        }

        public ActionResult Water()
        {

            return View();
        }

        public ActionResult Datacard()
        {

            return View();
        }

        public ActionResult Insurance()
        {

            return View();
        }

        public ActionResult MunicipalTax()
        {

            return View();
        }
    }
}
