using Backend.DbConnection;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers {

    public class FamilyController : ApiController {

        // Insert new Family
        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult Insert([FromBody]Family fa) {
            try {
                var res = FamilyConnection.InsertFamily(fa);
                fa.familyId = res;
                return Json(new { success = true, SuccesMsg = res });
            }
            catch (Exception ex)  {
                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }


        /// Get all Family Data
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllFamilies()  {
            try  {
                List<Family> result = new List<Family>();
                result = FamilyConnection.GetFamilyData();
                return Json(result);
            }
            catch (Exception ex) {
                return Json(ex.ToString());
            }
        }

        /// Get Family by ID, if doesnt exists return null
        [AcceptVerbs("GET")]
        public IHttpActionResult GetFamilyByID(int id)  {
            try {
                Family result = new Family();
                result = FamilyConnection.GetFamilyByID(id);
                return Json(result);
            }
            catch (Exception ex) {
                return Json(ex.ToString());
            }
        }

        /// Delete family 
        [AcceptVerbs("DELETE", "OPTIONS", "PUT")]
        public IHttpActionResult Delete(int id)  {
            try  {
                int result = -1;
                result = FamilyConnection.DeleteFamily(id);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)  {
                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }


        /// Update family
        [AcceptVerbs("PUT", "OPTIONS")]
        public IHttpActionResult Update([FromBody]Family fa)   {
            try   {
                int result = -1;
                result = FamilyConnection.UpdateFamily(fa);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)  {
                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }

        /// View family
        [AcceptVerbs("PUT", "OPTIONS")]
        public IHttpActionResult View([FromBody]Family fa)  {
            try {
                int result = -1;
                result = FamilyConnection.ViewFamily(fa);
                return Json(result);
            }
            catch (Exception ex)  {
                return Json(ex.ToString());
            }
        }

    }
}