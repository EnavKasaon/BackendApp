using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DbConnection {
    public static class VolunteerConnection {

        /// Insert new volunteer 
        public static int InsertVolunteer(Volunteer v) {
            int rowsNum = -1;
            try  {
                string Query = "INSERT INTO `volunteers_tbl` ( `volunteer_fname`, `volunteer_lname`, `phone`, `birth_date`, `volunteer_type` , `IdNum`) VALUES ('" + v.VolunteerFName+"', '"+v.VolunteerLName+"', '"+v.vPhone+"', '"+ v.BirthDate.ToString("yyyy-MM-dd") + "', '"+v.VolunteerType + "' , '" + v.IdNum + "'); SELECT LAST_INSERT_ID(); ";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                int newID = -1;
                while (MyReader2.Read()) {
                    newID = Int32.Parse(MyReader2[0].ToString());
                }
                MyConn2.Close();
                return newID;
            }
            catch (Exception ex) {
                return -1;  }
        }
                
        internal static object GetAllSuppliers()
        {
            throw new NotImplementedException();
        }
        public static List<Volunteer> GetTodayBirthdays()
        {
            List<Volunteer> volunteers = new List<Volunteer>();
            volunteers = GetVolunteerData(); // get all volunteers
            List<Volunteer> volunteersToday = new List<Volunteer>();
            foreach (Volunteer v in volunteers)
            {
                DateTime current= EventConnection.ChangeYear(v.BirthDate, DateTime.Now.Year);
                if (current.Date.Equals(DateTime.Now.Date)){
                    volunteersToday.Add(v);
                }
            }
            return volunteersToday;
        }

       
        /// Get All Volunteers Data without filtering
        public static List<Volunteer> GetVolunteerData()  {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Volunteer> volunteers = new List<Volunteer>();
            try {
                conn.Open(); //open the connection
                string Query = "SELECT * FROM volunteers_tbl";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (MyReader2.Read())
                {
                    volunteers.Add(new Volunteer() {
                        VolunteerId = Int32.Parse(MyReader2[0].ToString()),
                        VolunteerFName = MyReader2[1].ToString(),
                        VolunteerLName = MyReader2[2].ToString(),
                        vPhone = MyReader2[3].ToString(),
                        BirthDate = DateTime.Parse(MyReader2[4].ToString()),
                        VolunteerType = MyReader2[5].ToString(),
                        IdNum = MyReader2[6].ToString()
                    });

                }
                MyConn2.Close();  }
            catch (Exception)  {
                throw;
            }
            conn.Close();
            return volunteers;
        }


        /// Get Volunteers Details by id if doesnt existst, return null 
        public static Volunteer GetVolunteerByID(int id)  {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            Volunteer volunteerRequested = null;
            try {
                conn.Open(); //open the connection
                string Query = "SELECT * FROM `volunteers_tbl` WHERE 	volunteer_id =" + id + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                while (MyReader2.Read()) { 
                 //   while (rdr.Read())  {
                    volunteerRequested = new Volunteer()  {
                        VolunteerId = Int32.Parse(MyReader2[0].ToString()),
                        VolunteerFName = MyReader2[1].ToString(),
                        VolunteerLName = MyReader2[2].ToString(),
                        vPhone = MyReader2[3].ToString(),
                        BirthDate = DateTime.Parse(MyReader2[4].ToString()),
                        VolunteerType = MyReader2[5].ToString(),
                        IdNum = MyReader2[6].ToString()
                    };
                }
                MyConn2.Close(); }
            catch (Exception) {
                throw;
            }

            conn.Close();
            return volunteerRequested;
        }


        /// Update volunteer data using ID
        public static int UpdateVolunteer(Volunteer vo)  {
            int rowsNum = -1;
            try {
                string Query = "UPDATE `volunteers_tbl` SET `volunteer_fname`='" + vo.VolunteerFName + "',`volunteer_lname`='" + vo.VolunteerLName + "',`phone`='" + vo.vPhone + "',`birth_date`='" + vo.BirthDate.ToString("hh:mm tt") + "',`volunteer_type`='" + vo.VolunteerType + "'  ,`IdNum`='" + vo.IdNum + "' WHERE volunteer_id =" + vo.VolunteerId + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
                MyConn2.Close();
                return rowsNum; }
            catch (Exception ex)  {
                return rowsNum;
            }
        }

        /// View volunteer data using ID
        public static int ViewVolunteer(Volunteer vo)   {
            int rowsNum = -1;
            try  {
                string Query = "UPDATE `volunteers_tbl` SET `volunteer_fname`='" + vo.VolunteerFName + "',`volunteer_lname`='" + vo.VolunteerLName + "',`phone`='" + vo.vPhone + "',`birth_date`='" + vo.BirthDate.ToString("hh:mm tt") + "',`volunteer_type`='" + vo.VolunteerType + "' ,`IdNum`='" + vo.IdNum + "'  WHERE volunteer_id =" + vo.VolunteerId + ";";
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


        /// Delete volunteer
        public static int DeleteVolunteer(int id)  {
            int rowsNum = 0;
            try  {
                string Query = "DELETE FROM volunteers_tbl WHERE volunteer_id = " + id + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
                MyConn2.Close();
                return rowsNum;
            }
            catch (Exception ex) {
                return rowsNum = -1;
            }
        }

    }

}

