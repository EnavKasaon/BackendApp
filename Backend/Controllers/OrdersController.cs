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
        [AcceptVerbs("GET", "PUT", "OPTIONS")]
        public IHttpActionResult MarkOrderReceived([FromBody]Order o)
        {
            try
            {
                int result = 0;
                result = OrdersConnection.MarkOrderReceived(o);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }
        [AcceptVerbs("GET", "PUT", "OPTIONS")]
        public IHttpActionResult CheckIfTypeNameExists([FromBody]string name)
       {
            try
            {
                bool result = false;
                result = OrdersConnection.CheckIfOrderTypeNameExist(name);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, SuccesMsg = false });
            }
        }
        [AcceptVerbs("GET")]
        public IHttpActionResult GetOrdersByType(int id)
        {
            try
            {
                List<Order> result = new List<Order>();
                result = OrdersConnection.GetAllOrdersByType(id);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllOrders()
        {
            try
            {
                List<Order> result = new List<Order>();
                result = OrdersConnection.GetAllOrders();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }

        //[AcceptVerbs("GET", "PUT", "OPTIONS")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetTypeByID(int id)
        {
            try
            {
                OrderType result = new OrderType();
                result = OrdersConnection.GetOrderTypeByID(id);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }
        [AcceptVerbs("DELETE", "OPTIONS", "PUT")]
        public IHttpActionResult DeleteOrder(int id)
        {
            try
            {
                int result = -1;
                result = OrdersConnection.DeleteOrder(id);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, SuccesMsg = -1 });
            }
        }
        [AcceptVerbs("DELETE", "OPTIONS", "PUT")]
        public IHttpActionResult DeleteType(int id)
        {
            try
            {
                int result = -1;
                result = OrdersConnection.DeleteOrderType(id);
                //  return Json(result);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, SuccesMsg = -1 });
                //   return Json(ex.ToString());
            }
        }
        [AcceptVerbs("PUT", "OPTIONS")]
        public IHttpActionResult UpdateType([FromBody]OrderType ot)
        {
            try
            {
                int result = -1;
                result = OrdersConnection.UpdateType(ot);
                return Json(new { success = true, SuccesMsg = result });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, SuccesMsg = -1 });
            }
        }

    }
}
