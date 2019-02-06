﻿using Backend.DbConnection;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers {
    public class RegisterController : ApiController
    {
        /// Insert new User 
        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult Insert([FromBody]User us)  {
            try  {
                var res = RegisterConnection.InsertUser(us);
                us.userID = res;
                return Json(new { success = true, SuccesMsg = res });
            }
            catch (Exception ex) {
                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }



        /// Get all Users Data
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllUsers()  {
            try {
                List<User> res = new List<User>();
                res = RegisterConnection.GetUserData();
                return Json(res);
            }
            catch (Exception ex)  {
                return Json(ex.ToString());
            }
        }


        /// Get User by ID, if doesnt exists return null
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUserByID(int id)  {
            try  {
                User res = new User();
                res = RegisterConnection.GetUserByID(id);
                return Json(res);
            }
            catch (Exception ex)  {
                return Json(ex.ToString());
            }
        }


        // Check if email exist
        [AcceptVerbs("GET", "PUT", "OPTIONS")]
        public IHttpActionResult CheckIfEmailExist([FromBody]string email) {
            try {
                bool result = false;
                result = RegisterConnection.CheckIfEmailExist(email);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)  {
                return Json(new { success = false, SuccesMsg = false });
            }
        }

        /// Get User by Email, if doesnt exists return null
        //   [AcceptVerbs("GET")]
        //   public IHttpActionResult GetUserByEmail(string Email)  {
        //     try {
        //       User result = new User();
        //     result = RegisterConnection.GetUserByEmail(Email);
        //     r= "There is "
        //     return Json();
        //     }
        //     catch (Exception ex)  {
        //      return Json(new { success = false, ErrorMsg = ex.Message });
        //   }
        //      }


    }
}
