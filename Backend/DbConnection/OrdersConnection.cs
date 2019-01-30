using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Backend.DbConnection
{
    public class OrdersConnection
    {
        public static int InsertOrderType(OrderType ot)
        {
            try
            {
                
                string Query= "INSERT INTO `order_type_tbl`( `order_type_name`, `supplier_id`) VALUES ('" + ot.order_type_name + "','" + ot.supplier.ID + "'); SELECT LAST_INSERT_ID();";
                string Query_products = "";
                int order_type_id = 0;
                
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MyConn2.Open();
                MySqlCommand MyCommand2 = MyConn2.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MyConn2.BeginTransaction();
                MyCommand2.Connection = MyConn2;
                MyCommand2.Transaction = myTrans;
                try
                {
                    MyCommand2.CommandText = Query;
                    MySqlDataReader MyReader;
                    MyCommand2.ExecuteNonQuery();
                    order_type_id = Int32.Parse(MyCommand2.LastInsertedId.ToString());
                    foreach (Product p in ot.products) // update order_type_id in each product before insert
                    {
                        p.order_type_id = order_type_id;
                        Query_products += "INSERT INTO `product_in_order_type_tbl`( `order_type_id`, `product`, `amount`, `comments`) VALUES ('";
                        Query_products += +p.order_type_id + "','" + p.product_name + "','" + p.amount + "','" + p.comments + "');";
                    }
                    
                    MyCommand2.CommandText = Query_products;
                    MyCommand2.ExecuteNonQuery();
                    myTrans.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception e)
                {
                    try
                    {
                        myTrans.Rollback();
                        Console.WriteLine("An exception of type " + e.GetType() +
                    " was encountered while inserting the data.");
                        Console.WriteLine("Neither record was written to database.");
                    }
                    catch (SqlException ex)
                    {
                        if (myTrans.Connection != null)
                        {
                            Console.WriteLine("An exception of type " + ex.GetType() +
                            " was encountered while attempting to roll back the transaction.");
                        }
                    }

                    
                }
                finally
                {
                    MyConn2.Close();
                }
                return order_type_id;
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }

        public static int InsertOrder(Order o)
        {
            try
            {
                string Query = "INSERT INTO `order_tbl`( `order_type_id`, `order_date`) VALUES ('" + o.order_type.order_type_id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "'); SELECT LAST_INSERT_ID();";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                int newID = -1;
                while (MyReader2.Read())
                {
                    newID = Int32.Parse(MyReader2[0].ToString());
                }
                MyConn2.Close();
                return newID;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        /// <summary>
        /// If OrderType name already exist return true
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Boolean CheckIfOrderTypeNameExist(string name)
        {
            OrderType alreadyExist = GetOrderTypeByName(name);
            if (alreadyExist != null) 
            {
                return true;
            }
            return false;
        }
       
        /// <summary>
        /// Get product by ordertypeID and name
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="orderTypeID"></param>
        /// <returns></returns>
        public static Product GetProduct(string productName, int orderTypeID)
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            Product product = new Product();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `product_in_order_type_tbl` WHERE order_type_id ='" + orderTypeID + "' and product ='" + productName + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    product = new Product()
                    {
                        order_type_id = Int32.Parse(rdr[0].ToString()),
                        product_name = rdr[1].ToString(),
                        amount = Int32.Parse(rdr[2].ToString()),
                        comments = rdr[3].ToString()
                    };
                }
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return product;
        }

        public static List<Product> GetProductsInOrderType(int orderTypeID)
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Product> products = new List<Product>();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `product_in_order_type_tbl` WHERE order_type_id ='" + orderTypeID +  "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    products.Add( new Product()
                    {
                        order_type_id = Int32.Parse(rdr[0].ToString()),
                        product_name = rdr[1].ToString(),
                        amount = Int32.Parse(rdr[2].ToString()),
                        comments = rdr[3].ToString()
                    });
                }
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return products;
        }

        public static OrderType GetOrderTypeByID(int id)
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            OrderType type = new OrderType();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `order_type_tbl` WHERE order_type_id ='" + id + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    type = new OrderType()
                    {
                        order_type_id = Int32.Parse(rdr[0].ToString()),
                        order_type_name = rdr[1].ToString(),
                        supplier = SupplierConnection.GetSupplierByID(Int32.Parse(rdr[2].ToString()))
                    };
                }
                type.products = GetProductsInOrderType(id); // get all product of orderType
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return type;
        }

        public static List<OrderType> GetAllTypes()
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<OrderType> types = new List<OrderType>();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `order_type_tbl`;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                OrderType currentType = null;
                while (rdr.Read())
                {
                    
                    currentType = new OrderType()
                    {
                        order_type_id = Int32.Parse(rdr[0].ToString()),
                        order_type_name = rdr[1].ToString(),
                        supplier = SupplierConnection.GetSupplierByID(Int32.Parse(rdr[2].ToString()))
                    };
                    currentType.products = GetProductsInOrderType(currentType.order_type_id); // get all product of orderType
                    types.Add(currentType);
                   
                }
                
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return types;
        }


        public static OrderType GetOrderTypeByName(string name)
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            OrderType type = new OrderType();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `order_type_tbl` WHERE order_type_name ='" + name + "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    type = new OrderType()
                    {
                        order_type_id = Int32.Parse(rdr[0].ToString()),
                        order_type_name = rdr[1].ToString(),
                        supplier = SupplierConnection.GetSupplierByID(Int32.Parse(rdr[2].ToString()))
                    };
                }
                type.products = GetProductsInOrderType(type.order_type_id); // get all product of orderType
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return type;
        }

        public static int InsertProducts(List<Product> pr)
        {
            try
            {
                string Query = "";
                foreach(Product p in pr)
                {
                    Query += "INSERT INTO `product_in_order_type_tbl`( `order_type_id`, `product`, `amount`, `comments`) VALUES ('";
                    Query += +p.order_type_id + "','" + p.product_name + "','" + p.amount + "','" + p.comments + "');";
                }
               
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                int newID = 0;
                newID = MyReader2.RecordsAffected;
                MyConn2.Close();
                return newID;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}