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
        public static int InsertOrderType(OrderType e)
        {
            try
            {
                string Query = "INSERT INTO `order_type_tbl` ( `order_type_name`) VALUES ('" + e.order_type_name + "'); SELECT LAST_INSERT_ID();";
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
        public static OrderType GetOrderTypeByName( string name)
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            OrderType type = new OrderType();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM order_type_tbl WHERE order_type_name ='"+ name +"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    type = new OrderType() {
                        order_type_id = Int32.Parse(rdr[0].ToString()),
                        order_type_name = rdr[1].ToString()
                    };
                }
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return type;
        }
    }
}
