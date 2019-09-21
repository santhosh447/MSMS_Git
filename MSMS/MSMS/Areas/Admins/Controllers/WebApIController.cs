using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSMS.Areas.Admins.Models;
using MSMS.BuisnessAccessLayer;
using MSMS.Repositary;
using System.Web.Mvc;

namespace MSMS.Areas.Admins.Controllers
{
    public class WebApIController : ApiController
    {
        BAL ObjBal = new BAL(new Reposit());

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Api/WebApI/OwnerEmail/EId")]
        public HttpResponseMessage OwnerEmail(string EId)
        {
            try
            {
                using (  MSMSEntities db =  new MSMSEntities())
                {
                    var Owneremail = db.Owner_Registration.ToList();
                    if (Owneremail.Count > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK,Owneremail);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Record not Found");
                    }
                }
            }
            catch (Exception Ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Ex.Message.ToString());
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Api/WebApI/OwnerList")]
        public HttpResponseMessage OwnerList()
        {
            try
            {
                var listemp = ObjBal.OwnerList();
                if (listemp.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, listemp);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Record Not Found");
                }


            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message.ToString());
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Api/WebApI/StoreList")]
        public HttpResponseMessage StoreList(string value)
        {
            try
            {
                var liststore = ObjBal.StoreList(value);
                if (liststore.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, liststore);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Record Not Found");
                }


            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Ex.Message.ToString());
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Api/WebApI/Owner_Active_Count")]
        public HttpResponseMessage Owner_Active_Count()
        {
            try
            {
                int ListOwner = Convert.ToInt32(ObjBal.Owner_Active_Count());
                if (ListOwner != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListOwner);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not count Record find");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("Api/WebApI/Owner_Count")]
        public HttpResponseMessage Owner_Count()
        {
            try
            {
                int ListOwner = Convert.ToInt32(ObjBal.Owner_Count());
                if (ListOwner != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ListOwner);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not count Record find");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/WebApi/EmpCount")]
        public HttpResponseMessage EmpCount()
        {
            try
            {
                using (MSMSEntities db = new MSMSEntities())
                {
                    var EmpCount = db.Owner_Registration.Count();
                    if (EmpCount != 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, EmpCount);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record are not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
    }
}
