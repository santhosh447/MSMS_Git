using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSMS.Areas.Admins.Controllers
{
    public class ManageController : Controller
    {
        // GET: Admin/Manage
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult OwnerRegistrationAdd()
        {
            return View();
        }
        public ActionResult ManageOwnerRegAdd()
        {
            return View();
        }
        public ActionResult StoreAdd()
        {
            return View();
        }
        public ActionResult StoreManageAdd()
        {
            return View();
        }
    }
}