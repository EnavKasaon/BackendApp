using Backend.DbConnection;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers {
    public class LogInController : ApiController
    {



        /// Get all Users Data
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                List<User> res = new List<User>();
                res = RegisterConnection.GetUserData();
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }


        /// Get User by ID, if doesnt exists return null
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUserByID(int id)
        {
            try
            {
                User res = new User();
                res = RegisterConnection.GetUserByID(id);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }


        // Check if email exist
        //  [AcceptVerbs("GET", "PUT", "OPTIONS")]
        //public IHttpActionResult CheckIfPassAndNameExist([FromBody]string name1, [FromBody]string pass1)  {
        //  try  {
        //    bool result = false;
        //  result = LoginConnection.CheckIfPassAndNameExist(name1, pass1);
        //return Json(new { success = true, SuccesMsg = result });
        //}
        //catch (Exception ex) {
        //  return Json(new { success = false, SuccesMsg = false });
        //  }
        //    }
        //  }



        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult CheckIfPassAndNameExist([FromBody]User us) {
            try {
                string name1 = us.userName;
                string pass1 = us.Password;
                bool result = false;
                result = LoginConnection.CheckIfPassAndNameExist(name1, pass1);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex) {
                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }
    }
}