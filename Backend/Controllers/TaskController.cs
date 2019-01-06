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
    public class TaskController : ApiController
    {
        [AcceptVerbs("POST", "GET", "OPTIONS", "PUT")]
        public IHttpActionResult Insert([FromBody]Task t)
        {
            try
            {
                var res = TaskConnection.InsertTask(t);
                t.taskID = res;
                return Json(new { success = true, SuccesMsg = res });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, ErrorMsg = ex.Message });
            }
        }

        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllTasks()
        {
            try
            {
                List<Task> result = new List<Task>();
                result = TaskConnection.GetTaskData();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }

    }
}