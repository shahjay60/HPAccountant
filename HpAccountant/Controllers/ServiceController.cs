using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HpAccountant.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YearEndAccounts()
        {
            return View();
        }
        public ActionResult Bookkeeping()
        {
            return View();
        }
        public ActionResult Payroll()
        {
            return View();
        }
        public ActionResult SelfAssessment()
        {
            return View();
        }
        public ActionResult ManagementAccounting()
        {
            return View();
        }
    }
}