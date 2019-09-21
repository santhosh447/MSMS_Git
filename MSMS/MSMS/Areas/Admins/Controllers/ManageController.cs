using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSMS.BuisnessAccessLayer;
using MSMS.Repositary;
using MSMS.Areas.Admins.Models;


namespace MSMS.Areas.Admins.Controllers
{
    public class ManageController : Controller
    {
        BAL ObjBal = new BAL(new Reposit());
        // GET: Admins/Manage
        public ActionResult Dashboard()
        {
            var model = new Owner_Store_List();
            model.owner_list = ObjBal.OwnerData();
            model.store_list = ObjBal.StoreData();
            return View(model);
        }
        [HttpGet]
        public ActionResult OwnerRegistrationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OwnerRegistrationAdd(Owner_Registration Owner, string Register, HttpPostedFileBase Image, HttpPostedFileBase Image1, HttpPostedFileBase Image2)
        {
            if (Register == "Register")
            {
                Owner.Pan_Number = new byte[Image.ContentLength];
                Image.InputStream.Read(Owner.Pan_Number, 0, Image.ContentLength);

                Owner.Aadhar_Number = new byte[Image1.ContentLength];
                Image1.InputStream.Read(Owner.Aadhar_Number, 0, Image1.ContentLength);
               
                Owner.Owner_Image = new byte[Image2.ContentLength];
                Image2.InputStream.Read(Owner.Owner_Image, 0, Image2.ContentLength);
                ObjBal.InsertOwnerReg(Owner);

                Session["Owner_Email"] = Owner.Owner_Email;
                return RedirectToAction("StoreAdd");
            }


            return View();
        }
        [HttpGet]
        public ActionResult OwnerRegList()
        {
            return View(ObjBal.OwnerList());
        }




        public ActionResult ManageOwnerRegAdd()
        {
            return View();
        }
        [HttpGet]
        public ActionResult StoreAdd(Store_Registration store,string txtOwnerEmail,string ddlDepId)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult StoreAdd(Store_Registration store, string txtOwnerEmail, string ddlDepId, Owner_Registration owner, string Register, HttpPostedFileBase Image)
        {
            if ("Register" == "Register")
            {
                store.License_Image_Copy = new byte[Image.ContentLength];
                Image.InputStream.Read(store.License_Image_Copy, 0, Image.ContentLength);
                if (txtOwnerEmail == null)
                {
                    ObjBal.UpdateOwner(owner, ddlDepId);
                }
                else
                {
                    ObjBal.UpdateOwner(owner, txtOwnerEmail);
                }
                ObjBal.storeRegister(store);
                
            }
            return View();
        }
        public ActionResult StoreList(string value)
        {
            return View(ObjBal.StoreList(value));
        }

        public ActionResult StoreManageAdd()
        {
            return View();
        }
    }
}