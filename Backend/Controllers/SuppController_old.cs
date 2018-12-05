using Backend.DbConnection;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backend.Controllers
{

    public class SuppController_old : Controller
    {
        // GET: Supplier
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetSupplierName()
        {
            try
            {
                List<Supplier> result = new List<Supplier>();
                result = MySQLCon.GetSupplierData();
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Insert(Supplier su)
        {
            try
            {

                var res = MySQLCon.InsertSupplier(su);

                return Json(new { success = true, SuccesMsg = res }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                return Json(new { success = false, ErrorMsg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}