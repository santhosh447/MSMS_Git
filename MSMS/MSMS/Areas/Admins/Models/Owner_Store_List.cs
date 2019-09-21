using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSMS.Areas.Admins.Models;

namespace MSMS.Areas.Admins.Models
{
    public class Owner_Store_List
    {
        public IEnumerable<Owner_Registration> owner_list { get; set; }

        public IEnumerable<Store_Registration> store_list { get; set; }
    }
}