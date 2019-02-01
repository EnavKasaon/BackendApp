using Backend.DbConnection;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers {
    public class VolunteerController : ApiController {

        // Insert new Volunteer
        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult Insert([FromBody]Volunteer vo)  {
            try  {
                var res = VolunteerConnection.InsertVolunteer(vo);
                vo.VolunteerId = res;
                return Json(new { success = true, SuccesMsg = res });
            }
                    catch (Exception ex)   {
                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }
   


            /// Get all Volunteers Data
            [AcceptVerbs("GET")]
        public IHttpActionResult GetAllVolunteers() {
            try  {
                List<Volunteer> result = new List<Volunteer>();
                result = VolunteerConnection.GetVolunteerData();
                return Json(result);
            }
            catch (Exception ex) {
                return Json(ex.ToString());
            }
        }

        /// Get Volunteer by ID, if doesnt exists return null
        [AcceptVerbs("GET")]
        public IHttpActionResult GetVolunteerByID(int id)  {
            try  {
                Volunteer result = new Volunteer();
                result = VolunteerConnection.GetVolunteerByID(id);
                return Json(result);
            }
            catch (Exception ex)  {
                return Json(ex.ToString()); }
        }

        /// Delete volunteer 
        [AcceptVerbs("DELETE", "OPTIONS")]
        public IHttpActionResult Delete(int id)  {
            try  {
                int result = -1;
                result = VolunteerConnection.DeleteVolunteer(id);
                //  return Json(result); 
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)  {
                //     return Json(ex.ToString());
                return Json(new { success = false, ErrorMsg = ex.Message });

            }
        }


        /// Update volunteer
        [AcceptVerbs("PUT", "OPTIONS")]
        public IHttpActionResult Update([FromBody]Volunteer vo)  {
            try {
                int result = -1;
                result = VolunteerConnection.UpdateVolunteer(vo);
                // return Json(result);
                return Json(new { success = true, SuccesMsg = result });

            }
            catch (Exception ex)  {
                //   return Json(ex.ToString());
                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }

        /// View volunteer
        [AcceptVerbs("PUT", "OPTIONS")]
        public IHttpActionResult View([FromBody]Volunteer vo)  {
            try   {
                int result = -1;
                result = VolunteerConnection.ViewVolunteer(vo);
                return Json(result);
            }
            catch (Exception ex)  {
                return Json(ex.ToString());
            }
        }

    }
}