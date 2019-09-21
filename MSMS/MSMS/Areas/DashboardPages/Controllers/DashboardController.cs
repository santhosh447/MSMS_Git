using MSMS.Areas.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSMS.BuisnessAccessLayer;
using MSMS.IRepositary;
using MSMS.Repositary;
using System.Web.Security;

namespace MSMS.Areas.DashboardPages.Controllers
{
    public class DashboardController : Controller
    {
        BAL ObjBal = new BAL(new Reposit());
        // GET: DashboardPages/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sell()
        {
            return View();
        }
        public ActionResult Purchase()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult Profiles()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Owner log, string Login)
        {
            if (Login == "Login")
            {
                Owner_Registration emp = ObjBal.Owner_Login(log);
                if (emp != null)
                {
                    Session["Owner_Email"] = emp.Owner_Email;
                    Session["Owner_Image"] = emp.Owner_Image;
                    FormsAuthentication.SetAuthCookie(emp.Owner_Email, false);
                    return RedirectToAction("Branch", "DashBoard");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Branch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Branch(string Login, string ddlDeptId)
        {
            if (Login == "Login")
            {
                Session["StoreName"] = ddlDeptId;
                return RedirectToAction("Index", "DashBoard");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            // Redirecting to Login page after deleting Session
            return RedirectToAction("Login");
        }
    }
}