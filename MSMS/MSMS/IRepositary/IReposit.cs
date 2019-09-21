using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSMS.Areas.Admins.Models;




namespace MSMS.IRepositary
{
    public interface  IReposit
    {
        Admin CheckLoginUserName(LoginModel log);
        Owner_Registration InsertOwnerReg(Owner_Registration owner);
        List<Owner_Registration> OwnerList();
        List<Owner_Registration> EmailList(string EId);
        List<Store_Registration> StoreList(string value);
        Owner_Registration UpdateOwner(Owner_Registration owner);
        Store_Registration storeRegister(Store_Registration storeRegister);
        List<Owner_Registration> OwnerData();
         List<Store_Registration> StoreData();
        Owner_Registration UpdateOWner(Owner_Registration Owner, string ownerEmail);
        Store_Registration StoreUpdate(Store_Registration store);

        Store_Registration StoreEmail(string StoreEmail);

        int Owner_Count();

        int Owner_Active_Count();
        Owner_Registration Owner_Login(Owner login);

        List<Owner_Registration> Owner_Email(string ownerEmail);
        List<Store_Registration> Store_List(string value);



    }
}