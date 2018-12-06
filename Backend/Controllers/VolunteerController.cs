using Backend.DbConnection;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class VolunteerController : ApiController
    {
        // GET api/<controller>
        [AcceptVerbs("POST", "GET", "OPTIONS")]
        public IHttpActionResult Insert([FromBody]Volunteer v)
        {
            try
            {
                var res = VolunteerConnection.InsertVolunteer(v);
                return Json(res);
            }
            catch (Exception ex)
            {

                return Json(-1);
            }
        }
    }
}