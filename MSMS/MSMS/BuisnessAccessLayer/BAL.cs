using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSMS.Areas.Admins.Models;
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
        public Admin CheckLoginUserName(LoginModel log)
        {
            return Iobj.CheckLoginUserName(log);
        }
        public Owner_Registration InsertOwnerReg(Owner_Registration owner)
        {
            return Iobj.InsertOwnerReg(owner);
        }
        public List<Owner_Registration> OwnerList()
        {
            return Iobj.OwnerList();
        }
        public List<Owner_Registration> EmailList(string EId)
        {
            return Iobj.EmailList(EId);
        }
        public List<Store_Registration> StoreList(string value)
        {
            return Iobj.StoreList(value);
        }
        public Owner_Registration UpdateOwner(Owner_Registration owner, string ddlDepId)
        {
            return Iobj.UpdateOwner(owner);
        }
        public Store_Registration storeRegister(Store_Registration storeRegister)
        {
            return Iobj.storeRegister(storeRegister);
        }
        public List<Owner_Registration> OwnerData()
        {
            return Iobj.OwnerData();
        }
        public List<Store_Registration> StoreData()
        {
            return Iobj.StoreData();
        }
        public Owner_Registration UpdateOWner(Owner_Registration owner, string userId)
        {
            return Iobj.UpdateOWner(owner,userId);
        }
        public int Owner_Count()
        {
            return Iobj.Owner_Count();
        }
        public int Owner_Active_Count()
        {
            return Iobj.Owner_Active_Count();
        }
        public Owner_Registration Owner_Login(Owner login)
        {
            return Iobj.Owner_Login(login);
        }
        public List<Owner_Registration> Owner_Email(string ownerEmail)
        {
            return Iobj.Owner_Email(ownerEmail);
        }
        public List<Store_Registration> Store_List(string value)
        {
            return Iobj.Store_List(value);
        }
        //public Owner_Registration NewPassWord(Owner_Registration owner, string Password, string ownerEmail)
        //{
        //    return Iobj.NewPassWord(owner, Password, ownerEmail);
        //}
        public void SendMailTo(string To, string Subject, string Body)
        {
            Iobj.SendMailTo(To, Subject, Body);
        }
        public void ChagePassword(string owner, string Password)
        {
            Iobj.ChagePassword(owner, Password);
        }
    }
}