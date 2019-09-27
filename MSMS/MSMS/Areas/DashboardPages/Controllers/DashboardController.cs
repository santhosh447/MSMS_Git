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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using System.Text;

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
        [HttpGet]
        public ActionResult NewPassword(string ParamName)
        {
            if (ParamName == null)
            {
                return Content("Link Expired", "text/plain", Encoding.UTF8);
            }
            return View();
        }
        [HttpPost]
        public ActionResult NewPassword(string ParamName, string btnChange, string Password, string ConfirmPassword)
        {
            string DecryptParamName = Decrypt(ParamName);
            string[] ParamVals = DecryptParamName.Split(new char[] { ',' });
            DateTime ParamDate = Convert.ToDateTime(ParamVals[2]);

            if (btnChange == "Change")
            {
                if (Password == ConfirmPassword)
                {
                    if (DateTime.Now.Date == ParamDate)
                    {
                        ObjBal.ChagePassword(ParamVals[0], Password);
                    }
                    else
                    {
                        return Content("Link Expired", "text/plain", Encoding.UTF8);
                    }

                    return RedirectToAction("Index", "Dashboard", "DashboardPages");
                }
                else
                {
                    return Content("Confirm Password Should Be Same...!", "text/plain", Encoding.UTF8);
                }

            }
            //email = Session["Owner_Email"].ToString();

            return View();
        }
        [HttpGet]
        public ActionResult ChangePassWord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassWord(string Owner_Email, string btnSend)
        {
            string Email1 = Session["Owner_Email"].ToString();
            string Email2 = Owner_Email;
            string Date = DateTime.Now.Date.ToString();
            string Param = encrypt(Email1 + "," + Email2 + "," + Date);

            if (btnSend == "SendMail")
            {
                ObjBal.SendMailTo(Owner_Email, "You Can Change Password Here....! ", "http://localhost:50003/DashBoardPages/Dashboard/NewPassword?ParamName=" + Param);
                Response.Write("<script>alert('E-Mail Sent Successfully...!');</script>");
                return RedirectToAction("ChangePassword");
            }
            return View();
        }
        public string encrypt(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}