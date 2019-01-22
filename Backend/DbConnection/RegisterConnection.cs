using Backend.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Backend.DbConnection
{
    public static class RegisterConnection {

        /// Get All Users Data without filtering
        public static List<User> GetUserData()   {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<User> users = new List<User>();
            try  {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM login_tbl";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())  {
                    users.Add(new User()  {
                        userID = Int32.Parse(rdr[0].ToString()),
                        userName = rdr[1].ToString(),
                        Password = rdr[2].ToString(),
                        Email = rdr[3].ToString()
                    });
                }
                rdr.Close();  }
            catch (Exception)  {
                throw;  }

            conn.Close();
            return users;
        }

        /// Get Users Details by id if doesnt existst, return null 
        public static User GetUserByID(int id)   {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            User userRequested = null;
            try   {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `login_tbl` WHERE ID =" + id + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())  {
                    userRequested = new User()  {
                        userID = Int32.Parse(rdr[0].ToString()),
                        userName = rdr[1].ToString(),
                        Password = rdr[2].ToString(),
                        Email = rdr[3].ToString()
                    };
                }
                rdr.Close();
            }
            catch (Exception)  {
                throw;
            }
            conn.Close();
            return userRequested;
        }

        /// add new user to DB
        public static int InsertUser(User u)   {
            try  {
                string Query = "INSERT INTO `login_tbl`( `user_name`, `password`, `email`) VALUES ('" + u.userName + "','" + u.Password + "','" + u.Email + "'); SELECT LAST_INSERT_ID();";
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

        internal static object GetAllGetAllUsers() {
            throw new NotImplementedException();
        }


    }
}