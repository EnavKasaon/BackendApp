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
    public class SupplierController : ApiController {
        /// <summary>
        /// Insert new Supplier 
        /// </summary> 
        /// <param name="su"></param>
        /// <returns></returns>
        [AcceptVerbs("POST","GET", "OPTIONS", "PUT")]
        public IHttpActionResult Insert([FromBody]Supplier su)   {
            try {
                var res = SupplierConnection.InsertSupplier(su);
                su.ID = res;
               return Json(new { success = true, SuccesMsg = res });  }
            catch (Exception ex)  {
                
               return Json(new { success = false, ErrorMsg = ex.Message }); }
        }



        /// <summary>
        /// Get all Suppliers Data
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllSuppliers()  {
            try  {
                List<Supplier> result = new List<Supplier>();
                result = SupplierConnection.GetSupplierData();
                return Json(result);  }
            catch (Exception ex) {
                return Json(ex.ToString());
            }
        }


        /// <summary>
        /// Get Supplier by ID, if doesnt exists return null
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSupplierByID(int id)
        {
            try
            {
                Supplier result = new Supplier();
                result = SupplierConnection.GetSupplierByID(id);
                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(ex.ToString());
            }
        }
        /// <summary>
        /// delete supplier 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs("DELETE", "OPTIONS", "PUT")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int result = -1;
                result = SupplierConnection.DeleteSupplier(id);
                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(ex.ToString());
            }
        }
        /// <summary>
        /// update supplier
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [AcceptVerbs("PUT", "OPTIONS")]
        public IHttpActionResult Update([FromBody]Supplier s)
        {
            try
            {
                int result = -1;
                result = SupplierConnection.UpdateSupplier(s);
                return Json(result);

            }
            catch (Exception ex)
            {

                return Json(ex.ToString());
            }
        }

        /// view supplier
        [AcceptVerbs("PUT", "OPTIONS")]
        public IHttpActionResult View([FromBody]Supplier s)  {
            try  {
                int result = -1;
                result = SupplierConnection.ViewSupplier(s);
                return Json(result);
            }
            catch (Exception ex) {

                return Json(ex.ToString());
            }
        }



       // public FileResultSupplier Download()  {
         //   var supplier = SupplierConnection.GetAllSuppliers();
           // using (var outputStream = new MemoryStream())  {
             //   var writer = new CsvWriter(outputStream);
               // writer.WriteRow(new object[] { "ID", "SAP Name", "Opportunity Id", "Opportunity Name", "SFDC Product Name", "Cust Prod.", "SFDC ID", "Customer Name", "Flow", "FAB", "Mask Set Name", "Is Gm", "GM Name", "Map Status", "Created Date", "Reason" });
                //foreach (var product in products)  {
                  //  writer.WriteRow(new object[] { product.ProductId, product.SapName, product.OpportunityId, product.OpportunityName, product.SfdcName, product.CustomerProductName, product.SfdcId, product.CustomerName, product.Flow, product.FabName, product.MaskSetName, product.IsGM, product.GMProductName, product.MappingStatus, product.MappingDate, product.Reason });
                //}

           //     outputStream.Flush();
           //     outputStream.Seek(0, SeekOrigin.Begin);
           //     var data = outputStream.ToArray();
           //     var res = File(data, "application/octet");
           //     res.FileDownloadName = "bpm.products.csv";
             //   return res;
         //   }
      //  }
    }
}
