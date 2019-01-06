using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DbConnection
{
    public class TaskConnection
    {
        public static int InsertTask(Task t)
        {
            try
            {
                string Query = "INSERT INTO `task_tbl`( `task_desc`) VALUES ('" + t.taskDesc +  "'); SELECT LAST_INSERT_ID();";
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
        public static List<Task> GetTaskData()
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Task> tasks = new List<Task>();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM supplier_tbl";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tasks.Add(new Task()
                    {
                        taskID = Int32.Parse(rdr[0].ToString()),
                        taskDesc = rdr[1].ToString()
                       
                    });
                }
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return tasks;
        }
    }
}