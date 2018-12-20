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
              //  DateTime p = DateTime.Parse(v.BirthDate);
                //Console.WriteLine(p);
                string Query = "INSERT INTO `volunteers_tbl` ( `volunteer_fname`, `volunteer_lname`, `phone`, `birth_date`, `volunteer_type`) VALUES ('" + v.VolunteerFName+"', '"+v.VolunteerLName+"', '"+v.vPhone+"', '"+ v.BirthDate.ToString("yyyy-MM-dd") + "', '"+v.VolunteerType+"'); SELECT LAST_INSERT_ID(); ";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
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


        /// Get All Volunteers Data without filtering
        public static List<Volunteer> GetVolunteerData()  {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Volunteer> volunteers = new List<Volunteer>();
            try {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM volunteers_tbl";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())  {
                    volunteers.Add(new Volunteer() {
                        VolunteerId = Int32.Parse(rdr[0].ToString()),
                        VolunteerFName = rdr[1].ToString(),
                        VolunteerLName = rdr[2].ToString(),
                        vPhone = rdr[3].ToString(),
                      //  BirthDate = DateTime.Parse(rdr[4].ToString()),
                        VolunteerType = rdr[5].ToString()
                    });
                }
                rdr.Close();  }
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
                string sql = "SELECT * FROM `volunteers_tbl` WHERE 	volunteer_id =" + id + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())  {
                    volunteerRequested = new Volunteer()  {
                        VolunteerId = Int32.Parse(rdr[0].ToString()),
                        VolunteerFName = rdr[1].ToString(),
                        VolunteerLName = rdr[2].ToString(),
                        vPhone = rdr[3].ToString(),
                        BirthDate = DateTime.Parse(rdr[4].ToString()),
                        VolunteerType = rdr[5].ToString()
                    };
                }
                rdr.Close(); }
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
                string Query = "UPDATE `volunteers_tbl` SET `volunteer_fname`='" + vo.VolunteerFName + "',`volunteer_lname`='" + vo.VolunteerLName + "',`phone`='" + vo.vPhone + "',`birth_date`='" + vo.BirthDate.ToString("yyyy-MM-dd") + "',`volunteer_type`='" + vo.VolunteerType + "' WHERE volunteer_id =" + vo.VolunteerId + ";";
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
                string Query = "UPDATE `volunteers_tbl` SET `volunteer_fname`='" + vo.VolunteerFName + "',`volunteer_lname`='" + vo.VolunteerLName + "',`phone`='" + vo.vPhone + "',`birth_date`='" + vo.BirthDate.ToString("yyyy-MM-dd") + "',`volunteer_type`='" + vo.VolunteerType + "' WHERE volunteer_id =" + vo.VolunteerId + ";";
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

