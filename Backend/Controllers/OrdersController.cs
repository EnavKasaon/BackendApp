using Backend.DbConnection;
using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.Controllers
{
    public class OrdersController : ApiController
    {
        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult Insert([FromBody]OrderType ot)
        {
            try
            {
                var res = OrdersConnection.InsertOrderType(ot);
                ot.order_type_id = res;
                return Json(new { success = true, SuccesMsg = res });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }

    }
}
