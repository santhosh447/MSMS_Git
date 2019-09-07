using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSMS.Models;




namespace MSMS.IRepositary
{
    public interface  IReposit
    {
        Admins CheckUserNamePassword(LoginModel login);
    }
}