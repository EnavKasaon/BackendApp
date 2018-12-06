using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DbConnection
{
    public static class VolunteerConnection
    {
        /// <summary>
        /// insert new volunteer
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int InsertVolunteer(Volunteer v)
        {
            int rowsNum = -1;
            try
            {

                string Query = "INSERT INTO `volunteers_tbl` ( `volunteer_fname`, `volunteer_lname`, `phone`, `birth_date`, `volunteer_type`) VALUES ('"+v.VolunteerFName+"', '"+v.VolunteerLName+"', '"+v.Phone+"', '"+v.BirthDate+"', '"+v.VolunteerType+"');";
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
    }
}