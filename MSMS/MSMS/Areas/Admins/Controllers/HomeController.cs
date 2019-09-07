using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSMS.BuisnessAccessLayer;
using MSMS.Repositary;
using MSMS.Models;
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
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login, string BtnLogin)
        {
            if (BtnLogin == "Login")
            {
                if (ModelState.IsValid)
                {
                    if (ObjBal.CheckUserNamePassword(login) != null)
                    {

                        Admins ad = ObjBal.CheckUserNamePassword(login);
                        FormsAuthentication.SetAuthCookie(ad.Name, false);
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View();
        }

    }
}