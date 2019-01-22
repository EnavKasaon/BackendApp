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
    public class EventController : ApiController
    {
        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult Insert([FromBody]Event t)
        {
            try
            {
                var res = EventConnection.InsertEvent(t);
                t.event_id = res;
                return Json(new { success = true, SuccesMsg = res });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }

        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllEvents()
        {
            try
            {
                List<Event> result = new List<Event>();
                result = EventConnection.GetAll();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }
        [AcceptVerbs("DELETE", "OPTIONS", "PUT")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int result = -1;
                result = EventConnection.Delete(id);
                //  return Json(result);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ErrorMsg = ex.Message });
                //   return Json(ex.ToString());
            }
        }
    }
}
