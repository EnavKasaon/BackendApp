using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Backend.DbConnection {
    public static class LoginConnection
    {
        internal static bool CheckIfPassnameExist(string name1, string pass1)
        {
            throw new NotImplementedException();
        }
  

    /// Get All Users Data without filtering
    public static List<User> GetUserData()  {
        MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
        List<User> users = new List<User>();
        try {
            conn.Open(); //open the connection
            string sql = "SELECT * FROM login_tbl";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())  {
                users.Add(new User()  {
                    userID = Int32.Parse(rdr[0].ToString()),
                    userName = rdr[1].ToString(),
                    Password = rdr[2].ToString(),
                    Email = rdr[3].ToString(),
                    confirmPassword = rdr[4].ToString()
                });
            }
            rdr.Close();
        }
        catch (Exception)  {
            throw;
        }

        conn.Close();
        return users;
    }

    /// Get Users Details by id if doesnt existst, return null 
    public static User GetUserByID(int id) {
        MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
        User userRequested = null;
        try   {
            conn.Open(); //open the connection
            string sql = "SELECT * FROM `login_tbl` WHERE ID =" + id + ";";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())    {
                userRequested = new User()    {
                    userID = Int32.Parse(rdr[0].ToString()),
                    userName = rdr[1].ToString(),
                    Password = rdr[2].ToString(),
                    Email = rdr[3].ToString(),
                    confirmPassword = rdr[4].ToString()
                };
            }
            rdr.Close();
        }
        catch (Exception)    {
            throw;
        }
        conn.Close();
        return userRequested;
    }



    // Get user by email
    public static User GetUserByPass(string name1, string pass1)  {
        MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
        User user = null;
        try  {
            conn.Open(); //open the connection
           // string sql = "SELECT * FROM `login_tbl` WHERE user_name=" + name1 + " AND password=" + pass1 + " LIMIT 1;";
            string sql = "SELECT * FROM `login_tbl` WHERE user_name ='" + name1 + "' AND password ='" + pass1 + "'LIMIT 1;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())   {
                user = new User()   {
                    userID = Int32.Parse(rdr[0].ToString()),
                    userName = rdr[1].ToString(),
                    Password = rdr[2].ToString(),
                    Email = rdr[3].ToString(),
                    confirmPassword = rdr[4].ToString()
                };
            }
            if (user.userID != 0) {
            }
            rdr.Close();
        }
        catch (Exception)  {
            throw;
        }
        conn.Close();
        return user;
    }




    // Check If user'd email Exist
    public static bool CheckIfPassAndNameExist(string name1, string pass1)  {
        User alreadyExist = GetUserByPass(name1, pass1);
        if (alreadyExist != null)  {
            return true;
        }
        return false;
    }

    }
}

