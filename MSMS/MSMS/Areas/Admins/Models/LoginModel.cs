using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MSMS.Areas.Admins.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Please Enter Email")]
        public string EmailAddress { get; set; }


        


        [Required(ErrorMessage = "Please Enter Employee Password")]
        //[MaxLength(8, ErrorMessage = "Password must be 8 Character")]
        //[MinLength(4, ErrorMessage = "Password Must be start from 4 Character")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "please enter one capital four small numerical special characher ")]
        public String password { get; set; }
    }
}