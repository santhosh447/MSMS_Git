using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSMS.BuisnessAccessLayer;
using MSMS.Repositary;
using MSMS.Areas.Admins.Models;

using System.Web.Security;

namespace MSMS.Areas.Admins.Controllers
{

    public class HomeController : Controller
    {
        BAL ObjBal = new BAL(new Reposit());
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AboutUs()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel log, string login)
        {
            if (login == "login")
            {
                if (ModelState.IsValid)
                {

                   Models.Admin emp = ObjBal.CheckLoginUserName(log);
                    if (emp != null)
                    {
                        FormsAuthentication.SetAuthCookie(emp.Name, false);
                        return RedirectToAction("Dashboard", "Manage");
                    }
                }
            }
            return View();
        }

    }
}