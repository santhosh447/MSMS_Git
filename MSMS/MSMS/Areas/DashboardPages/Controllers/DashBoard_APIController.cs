using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSMS.Repositary;
using MSMS.Areas.Admins.Models;
using MSMS.IRepositary;
using MSMS.BuisnessAccessLayer;

namespace MSMS.Areas.DashboardPages.Controllers
{
    public class DashBoard_APIController : ApiController
    {
        BAL ObjBal = new BAL(new Reposit());
            [HttpGet]
            [Route("Api/DashBoard_API/Email_Owner/{value}")]
            public HttpResponseMessage Email_Owner(string value)
            {
                try
                {
                    var Email_Owner = ObjBal.Owner_Email(value);
                    if (Email_Owner.Count > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, Email_Owner);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Records are Not there in Store database");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
                }
            }
            [HttpGet]
            [Route("Api/DashBoard_API/Store_List")]
            public HttpResponseMessage Store_List(string value)
            {
                try
                {
                    using (MSMSEntities db = new MSMSEntities())
                    {
                        var OwnerGender = ObjBal.Store_List(value);
                        if (OwnerGender != null)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, OwnerGender);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "Owner are not found in the id called:" + value);
                        }
                    }

                }
                catch (Exception Ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Ex.Message.ToString());
                }
            }
        }
    }

