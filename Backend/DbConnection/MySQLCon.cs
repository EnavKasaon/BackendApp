using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Backend.Models;

namespace Backend.DbConnection
{
    public static class MySQLCon
    {
        
        public static string conString = "user id=root;server=127.0.0.1;persistsecurityinfo=True;database=ahvaandhesed_db; CharSet=utf8";
        public static MySqlConnection conn = new MySqlConnection(conString);


      
    }
    
}