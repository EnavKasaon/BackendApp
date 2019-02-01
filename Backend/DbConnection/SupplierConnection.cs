using Backend.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Backend.DbConnection
{
    public static class SupplierConnection {

        /// <summary>
        /// Get All Suppliers Data without filtering
        /// </summary>
        /// <returns></returns>
        public static List<Supplier> GetSupplierData()   {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Supplier> suppliers = new List<Supplier>();
            try  {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM supplier_tbl";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())  {
                    suppliers.Add(new Supplier()  {
                        ID = Int32.Parse(rdr[0].ToString()),
                        companyName = rdr[1].ToString(),
                        Phone = rdr[2].ToString(),
                        Fax = rdr[3].ToString(),
                        ContactPerson = rdr[4].ToString(),
                        ContactPhone = rdr[5].ToString(),
                        GoodsType = rdr[6].ToString(),
                        SupplierType = rdr[7].ToString()
                    });
                }
                rdr.Close();  }
            catch (Exception)  {
                throw;  }

            conn.Close();
            return suppliers;
        }
        /// <summary>
        /// Get Supplier Details by id if doesnt existst, return null 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Supplier GetSupplierByID(int id)
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            Supplier supplierRequested = null;
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `supplier_tbl` WHERE ID =" + id + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    supplierRequested = new Supplier()
                    {
                        ID = Int32.Parse(rdr[0].ToString()),
                        companyName = rdr[1].ToString(),
                        Phone = rdr[2].ToString(),
                        Fax = rdr[3].ToString(),
                        ContactPerson = rdr[4].ToString(),
                        ContactPhone = rdr[5].ToString(),
                        GoodsType = rdr[6].ToString(),
                        SupplierType = rdr[7].ToString()
                    };

                }
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return supplierRequested;
        }

        /// <summary>
        /// add new Supplier to DB
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int InsertSupplier(Supplier s)   {
            try  {
                string Query = "INSERT INTO `supplier_tbl`( `company_name`, `phone`, `fax`, `contact_person`, `contact_phone`, `goods_type`, `supplier_type`) VALUES ('" + s.companyName + "','" + s.Phone + "','" + s.Fax + "','" + s.ContactPerson + "','" + s.ContactPhone + "','" + s.GoodsType + "','" + s.SupplierType + "'); SELECT LAST_INSERT_ID();";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                int newID = -1;
                while (MyReader2.Read())  {
                    newID = Int32.Parse(MyReader2[0].ToString());  }
                MyConn2.Close();
                return newID;  }
            catch (Exception ex)   {
                return -1;  }
        }

        internal static object GetAllSuppliers()  {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Update supplier data using ID
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int UpdateSupplier(Supplier s)   {
            int rowsNum = -1;
            try
            {
                string Query = "UPDATE `supplier_tbl` SET `company_name`='"+s.companyName+"',`phone`='"+s.Phone+"',`fax`='"+s.Fax+"',`contact_person`='"+s.ContactPerson+"',`contact_phone`='"+s.ContactPhone+"',`goods_type`='"+s.GoodsType+"',`supplier_type`='"+s.SupplierType+"' WHERE ID ="+s.ID+";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
                MyConn2.Close();
                return rowsNum;
            }
            catch (Exception ex)
            {
                return rowsNum;
            }
        }


        /// View supplier data using ID
        public static int ViewSupplier(Supplier s) {
            int rowsNum = -1;
            try  {
                string Query = "UPDATE `supplier_tbl` SET `company_name`='" + s.companyName + "',`phone`='" + s.Phone + "',`fax`='" + s.Fax + "',`contact_person`='" + s.ContactPerson + "',`contact_phone`='" + s.ContactPhone + "',`goods_type`='" + s.GoodsType + "',`supplier_type`='" + s.SupplierType + "' WHERE ID =" + s.ID + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  

                MyConn2.Close();
                return rowsNum;
            }
            catch (Exception ex)  {
                return rowsNum;
            }
        }


        /// <summary>
        /// delete supplier
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int DeleteSupplier(int id)  {
            int rowsNum = -1;
            try  {
                string Query = "DELETE FROM supplier_tbl WHERE ID = "+id+";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
                MyConn2.Close();
                return rowsNum;  }
            catch (Exception ex)  {
                return rowsNum;
            }
        }
    }
}