using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSMS.IRepositary;
using MSMS.Areas.Admins.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace MSMS.Repositary
{
    public class Reposit : IReposit
    {
        public void ChagePassword(string owner, string Password)
        {
            try
            {
                string strcon = ConfigurationManager.ConnectionStrings["MSMS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(strcon))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update owner_Registration set Password=@Password where Owner_Email=@Owner_Email";
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Owner_Email", owner);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Admin CheckLoginUserName(LoginModel log)
        {
            using (MSMSEntities db = new MSMSEntities())
            {
                return db.Admins.Where(m => m.Admin_ID == log.EmailAddress && m.Phone == log.password).FirstOrDefault();

            }
        }

        public List<Owner_Registration> EmailList(string EId)
        {
            List<Owner_Registration> listdepno = new List<Owner_Registration>();
            try
            {
                using (MSMSEntities db = new MSMSEntities())
                {
                    listdepno = db.Owner_Registration.Where(m => m.Owner_Email == EId).ToList();
                }
            }
            catch (Exception Ex)
            {

            }
            return listdepno;
        }

        public Owner_Registration InsertOwnerReg(Owner_Registration owner)
        {
            try
            {
                using (MSMSEntities db = new MSMSEntities())
                {
                    db.Owner_Registration.Add(owner);
                    db.SaveChanges();
                }

            }
            catch (Exception Ex)
            {

            }
            return owner;
        }

        //public Owner_Registration NewPassWord(Owner_Registration owner, string Password, string ownerEmail)
        //{
        //    string strcon = ConfigurationManager.ConnectionStrings["MSMSDB"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(strcon))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("update Owner_Registration set Password='" + Password + "' where Owner_Email='" + ownerEmail + "'", con);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //    return owner;
        //}

        public List<Owner_Registration> OwnerData()
        {
            using (MSMSEntities db = new MSMSEntities())
            {
                return db.Owner_Registration.ToList();
            }
        }

        public List<Owner_Registration> OwnerList()
        {
            List<Owner_Registration> Ownlist = new List<Owner_Registration>();
            try
            {
                using (MSMSEntities db = new MSMSEntities())
                {
                    Ownlist = db.Owner_Registration.ToList();
                }
            }
            catch (Exception Ex)
            {

            }
            return Ownlist;
        }

        public int Owner_Active_Count()
        {
            int cn;
            string strcon = ConfigurationManager.ConnectionStrings["MSMS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) as StatusCount from Owner_Registration where Status='Pending'", con);
                int count = (Int32)cmd.ExecuteScalar();
                cn = Convert.ToInt32(count);
            }
            return cn;
        }

        public int Owner_Count()
        {
            int cn;
            //Owner_Registration cn = new Owner_Registration();
            string strcon = ConfigurationManager.ConnectionStrings["MSMS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) as StatusCount from Owner_Registration where Status='Active'", con);
                int count = (Int32)cmd.ExecuteScalar();
                cn = Convert.ToInt32(count);
            }
            return cn;
        }

        public List<Owner_Registration> Owner_Email(string ownerEmail)
        {
            List<Owner_Registration> owner = new List<Owner_Registration>();
            using (MSMSEntities db = new MSMSEntities())
            {
                owner = db.Owner_Registration.Where(m => m.Owner_Email == ownerEmail).ToList();
            }
            return owner;
        }

        public Owner_Registration Owner_Login(Owner login)
        {
            using (MSMSEntities db = new MSMSEntities())
            {
                return db.Owner_Registration.Where(m => m.Owner_Email == login.Owner_Email && m.Password == login.Password).SingleOrDefault();
            }
        }

        public void SendMailTo(string To, string Subject, string Body)
        {
            SmtpClient smtpc = new SmtpClient("smtp.gmail.com");
            smtpc.Port = 587;
            smtpc.EnableSsl = true;
            smtpc.UseDefaultCredentials = false;
            string userId = "kalphakursanthosh.vtalent@gmail.com"; //<--Enter your gmail id here
            string pass = "Sampath@123"; //<--Enter Your gmail password here           
            string body = Body;  //Message body
            smtpc.Credentials = new NetworkCredential(userId, pass);
            MailMessage message = new MailMessage();
            message.To.Add(To);// Email-ID of Receiver  
            message.Subject = Subject;// Subject of Email  
            message.From = new System.Net.Mail.MailAddress("kalphakursanthosh.vtalent@gmail.com");// Email-ID of Sender  
            message.IsBodyHtml = true;
            message.Body = body;
            smtpc.Send(message);
        }

        public List<Store_Registration> StoreData()
        {
            using (MSMSEntities db = new MSMSEntities())
            {
                return db.Store_Registration.ToList();
            }
        }

        public Store_Registration StoreEmail(string StoreEmail)
        {
            throw new NotImplementedException();
        }

        public List<Store_Registration> StoreList(string value)
        {
            List<Store_Registration> Storelist = new List<Store_Registration>();
            try
            {
                using (MSMSEntities db = new MSMSEntities())
                {
                    Storelist = db.Store_Registration.Where(m => m.Owner_Email == value).ToList();
                }
            }
            catch (Exception Ex)
            {

            }
            return Storelist;
        }

        public Store_Registration storeRegister(Store_Registration storeRegister)
        {
            using (MSMSEntities db = new MSMSEntities())
            {
                db.Store_Registration.Add(storeRegister);
                db.SaveChanges();
            }
            return storeRegister;
        }

        public Store_Registration StoreUpdate(Store_Registration store)
        {
            throw new NotImplementedException();
        }

        public List<Store_Registration> Store_List(string value)
        {
            List<Store_Registration> owner = new List<Store_Registration>();
            try
            {
                using (MSMSEntities db = new MSMSEntities())
                {
                    owner = db.Store_Registration.Where(m => m.Owner_Email == value).ToList();
                }

            }
            catch (Exception Ex)
            {

            }
            return owner;
        }

        public Owner_Registration UpdateOwner(Owner_Registration owner)
        {

            Owner_Registration listUp = new Owner_Registration();
            try
            {
                using (MSMSEntities db = new MSMSEntities())
                {

                    //listUp= db.Entry(owner).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(owner).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception Ex)
            {

            }

            return owner;
               
        }

        public Owner_Registration UpdateOWner(Owner_Registration owner, string ownerEmail)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MSMS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Owner_Registration set Status='Active' where Owner_Email='" + ownerEmail + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return owner;
        }
    }
}