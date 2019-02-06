using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DbConnection
{
    public class EventConnection
    {
        public static int InsertEvent(Event e)
        {
            try
            {
                string Query = "INSERT INTO `events_tbl` ( `event_desc`, `start_date`, `end_date`, `color`) VALUES ('" + e.event_desc + "','"+ e.start_date.ToString("yyyy-MM-dd HH:mm") + "','" + e.end_date.ToString("yyyy-MM-dd HH:mm") + "','" + e.color + "'); SELECT LAST_INSERT_ID();";
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

        public static int UpdateEvent(Event e)
        {
            try
            {
                
                string Query = "UPDATE `events_tbl` SET `event_desc` = '"+e.event_desc+ "' , start_date = '" + e.start_date.ToString("yyyy-MM-dd HH:mm") + "' , `end_date` = '"+e.end_date.ToString("yyyy-MM-dd HH:mm") + "' , `color` ='" + e.color+"' WHERE event_id =" + e.event_id + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                int rows = MyCommand2.ExecuteNonQuery();

                MyConn2.Close();
                return rows;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static DateTime ChangeYear(DateTime dt, int newYear)
        {
            return dt.AddYears(newYear - dt.Year);
        }

        public static List<Event> GetBirthdays()
        {
            
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Event> birthdays = new List<Event>();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `volunteers_tbl`";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime dt = DateTime.Parse(rdr[4].ToString());
                    
                    
                    birthdays.Add(new Event()
                    {
                        event_id = Int32.Parse(rdr[0].ToString()),
                        event_desc = string.Format("{0} {1}",rdr[1].ToString(), rdr[2].ToString()),
                        start_date = ChangeYear(DateTime.Parse(rdr[4].ToString()), DateTime.Now.Year),
                        end_date = ChangeYear(DateTime.Parse(rdr[4].ToString()),DateTime.Now.Year),
                        color = "red"
                    });
                }
                rdr.Close();
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return birthdays;
        }

        public static List<Event> GetAll()
        {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Event> tasks = new List<Event>();
            try
            {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM events_tbl";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime dt = DateTime.Parse(rdr[2].ToString());
                    string st = dt.ToString();
                    tasks.Add(new Event()
                    {
                        event_id = Int32.Parse(rdr[0].ToString()),
                        event_desc = rdr[1].ToString(),
                        start_date = DateTime.Parse(rdr[2].ToString()),
                        end_date = DateTime.Parse(rdr[3].ToString()),
                        color = rdr[4].ToString()
                    });
                }
                rdr.Close();
                tasks.AddRange(GetBirthdays());
            }
            catch (Exception)
            {
                throw;
            }

            conn.Close();
            return tasks;
        }
        public static int Delete(int id)
        {
            int rowsNum = -1;
            try
            {
                string Query = "DELETE FROM events_tbl WHERE event_id = " + id + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
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
    }
}