using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSMS.Models;
using MSMS.IRepositary;
using MSMS.Repositary;


namespace MSMS.BuisnessAccessLayer
{
    public class BAL
    {
        IReposit Iobj;
        public BAL(Reposit _Iobj)
        {
            Iobj = _Iobj;
        }
        public Admins CheckUserNamePassword(LoginModel login)
        {
            return Iobj.CheckUserNamePassword(login);
        }
    }
}