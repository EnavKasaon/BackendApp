using Backend.DbConnection;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend.Controllers
{
    public class SupplierController : ApiController
    {
        /// <summary>
        /// Insert new Supplier 
        /// </summary>
        /// <param name="su"></param>
        /// <returns></returns>
        [AcceptVerbs("POST","GET", "OPTIONS")]
        public IHttpActionResult Insert([FromBody]Supplier su)
        {
            try
            {
                var res = MySQLCon.InsertSupplier(su);
                su.ID = res;
               return Json(new { success = true, SuccesMsg = res });
            }
            catch (Exception ex)
            {
                
               return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }
        /// <summary>
        /// Get all Suppliers Data
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllSuppliers()
        {
            try
            {
                List<Supplier> result = new List<Supplier>();
                result = MySQLCon.GetSupplierData();
                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(ex.ToString());
            }
        }
    }
}
