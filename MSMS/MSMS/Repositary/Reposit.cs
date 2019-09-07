using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSMS.IRepositary;
using MSMS.Models;

namespace MSMS.Repositary
{
    public class Reposit : IReposit
    {
        public Admins CheckUserNamePassword(LoginModel login)
        {
            using (MSMSEntities Db = new MSMSEntities())
            {
                return Db.Admins.Where(m => m.Admin_ID == login.EmailAddress && m.Phone == login.password).FirstOrDefault();

            }
        }
    }
}