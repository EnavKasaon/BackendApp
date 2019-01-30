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
        public IHttpActionResult InsertType([FromBody]OrderType ot)
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
        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult InsertOrder([FromBody]Order o)
        {
            try
            {
                var res = OrdersConnection.InsertOrder(o);
                o.order_id = res;
                return Json(new { success = true, SuccesMsg = res });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllTypes()
        {
            try
            {
                List<OrderType> result = new List<OrderType>();
                result = OrdersConnection.GetAllTypes();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }

    }
}
