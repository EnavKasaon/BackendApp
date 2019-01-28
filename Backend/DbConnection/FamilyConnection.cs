using Backend.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.DbConnection {
    public static class FamilyConnection  {


        /// Insert new family 
        public static int InsertFamily(Family f)  {
            int rowsNum = -1;
            try  {
                int testInt = f.car ? 1 : 0;
                int testing = Convert.ToInt32(f.car);
                string Query = "INSERT INTO `family_tbl` ( `first_Name`, `last_Name`, `street`, `house_Num`, `floor`, `phone`, `people_Number`, `notes`, `how_Did_You_Hear`, `reason_For_Referral`, `join_Date`, `family_Type`, `basket_Type`, `house`, `car`, `debt`, `pay_Checks`, `bituah_Leumi`, `bank_Account`, `credit_card`, `copy_Id`, `rent_Contract' ) VALUES ('" + f.firstName + "', '" + f.lastName + "', '" + f.street + "', '" + f.houseNum + "', '" + f.floor + "', '" + f.phone + "', '" + f.peopleNumber + "', '" + f.notes + "', '" + f.howDidYouHear + "', '" + f.reasonForReferral + "', '" + f.joinDate.ToString("yyyy-MM-dd") + "', '" + f.familyType + "', '" + f.basketType + "', '" + f.house + "', '" + f.car + "', '" + f.debt + "', '" + f.payChecks + "', '" + f.bituahLeumi + "', '" + f.bankAccount + "', '" + f.creditCard + "', '" + f.copyId + "', '" + f.rentContract + "'); SELECT LAST_INSERT_ID();";
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
            catch (Exception ex)  {
                return -1;
            }
        }


        /// Get All Families Data without filtering
        public static List<Family> GetFamilyData()  {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            List<Family> families = new List<Family>();
            try  {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM family_tbl";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) {
                    families.Add(new Family()  {
                        familyId =Int32.Parse(rdr[0].ToString()),
                        firstName = rdr[1].ToString(),
                        lastName = rdr[2].ToString(),
                        street = rdr[3].ToString(),
                        houseNum = rdr[4].ToString(),
                        floor =Int32.Parse(rdr[5].ToString()),
                        phone =Int32.Parse(rdr[6].ToString()),
                        peopleNumber =Int32.Parse(rdr[7].ToString()),
                        notes = rdr[8].ToString(),
                        howDidYouHear = rdr[9].ToString(),
                        reasonForReferral = rdr[10].ToString(),
                      //  joinDate = DateTime.Parse(rdr[11].ToString()),
                        familyType = rdr[12].ToString(),
                        basketType = rdr[13].ToString(),
                        house = Boolean.Parse(rdr[14].ToString()),
                        car = Boolean.Parse(rdr[15].ToString()),
                        debt = Boolean.Parse(rdr[16].ToString()),
                        payChecks = Boolean.Parse(rdr[17].ToString()),
                        bituahLeumi = Boolean.Parse(rdr[18].ToString()),
                        bankAccount = Boolean.Parse(rdr[19].ToString()),
                        creditCard = Boolean.Parse(rdr[20].ToString()),
                        copyId = Boolean.Parse(rdr[21].ToString()),
                        rentContract = Boolean.Parse(rdr[22].ToString())

                    });
                }
                rdr.Close();
            }
            catch (Exception)  {
                throw;
            }
            conn.Close();
            return families;
        }


        /// Get Family Details by id if doesnt existst, return null 
        public static Family GetFamilyByID(int id)  {
            MySqlConnection conn = new MySqlConnection(MySQLCon.conString);
            Family familyRequested = null;
            try {
                conn.Open(); //open the connection
                string sql = "SELECT * FROM `family_tbl` WHERE 	family_Id =" + id + ";";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())   {
                    familyRequested = new Family() {
                        familyId = Int32.Parse(rdr[0].ToString()),
                        firstName = rdr[1].ToString(),
                        lastName = rdr[2].ToString(),
                        street = rdr[3].ToString(),
                        houseNum = rdr[4].ToString(),
                        floor = Int32.Parse(rdr[5].ToString()),
                        phone = Int32.Parse(rdr[6].ToString()),
                        peopleNumber = Int32.Parse(rdr[7].ToString()),
                        notes = rdr[8].ToString(),
                        howDidYouHear = rdr[9].ToString(),
                        reasonForReferral = rdr[10].ToString(),
                     //   joinDate = DateTime.Parse(rdr[11].ToString()),
                        familyType = rdr[12].ToString(),
                        basketType = rdr[13].ToString(),
                        house = Boolean.Parse(rdr[14].ToString()),
                        car = Boolean.Parse(rdr[15].ToString()),
                        debt = Boolean.Parse(rdr[16].ToString()),
                        payChecks = Boolean.Parse(rdr[17].ToString()),
                        bituahLeumi = Boolean.Parse(rdr[18].ToString()),
                        bankAccount = Boolean.Parse(rdr[19].ToString()),
                        creditCard = Boolean.Parse(rdr[20].ToString()),
                        copyId = Boolean.Parse(rdr[21].ToString()),
                        rentContract = Boolean.Parse(rdr[22].ToString())
                    };
                }
                rdr.Close();
            }
            catch (Exception)  {
                throw;  }
            conn.Close();
            return familyRequested;
        }


        /// Update family data using ID
        public static int UpdateFamily(Family fa)   {
            int rowsNum = -1;
            try   {
                string Query = "UPDATE `family_tbl` SET `first_Name`, `last_Name`, `street`, `house_Num`, `floor`, `phone`, `people_Number`, `notes`, `how_Did_You_Hear`, `reason_For_Referral`, `join_Date`, `family_Type`, `basket_Type`, `house`, `car`, `debt`, `pay_Checks`, `bituah_Leumi`, `bank_Account`, `credit_card`, `copy_Id`, `rent_Contract' ) VALUES ('" + fa.firstName + "', '" + fa.lastName + "', '" + fa.street + "', '" + fa.houseNum + "', '" + fa.floor + "', '" + fa.phone + "', '" + fa.peopleNumber + "', '" + fa.notes + "', '" + fa.howDidYouHear + "', '" + fa.reasonForReferral + "', '" + fa.joinDate.ToString("yyyy-MM-dd") + "', '" + fa.familyType + "', '" + fa.basketType + "', '" + fa.house + "', '" + fa.car + "', '" + fa.debt + "', '" + fa.payChecks + "', '" + fa.bituahLeumi + "', '" + fa.bankAccount + "', '" + fa.creditCard + "', '" + fa.copyId + "', '" + fa.rentContract + "');";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
                MyConn2.Close();
                return rowsNum;
            }
            catch (Exception ex) {
                return rowsNum;
            }
        }

        /// View family data using ID
        public static int ViewFamily(Family fa)  {
            int rowsNum = -1;
            try  {
                string Query = "UPDATE `family_tbl` SET `first_Name`, `last_Name`, `street`, `house_Num`, `floor`, `phone`, `people_Number`, `notes`, `how_Did_You_Hear`, `reason_For_Referral`, `join_Date`, `family_Type`, `basket_Type`, `house`, `car`, `debt`, `pay_Checks`, `bituah_Leumi`, `bank_Account`, `credit_card`, `copy_Id`, `rent_Contract' ) VALUES ('" + fa.firstName + "', '" + fa.lastName + "', '" + fa.street + "', '" + fa.houseNum + "', '" + fa.floor + "', '" + fa.phone + "', '" + fa.peopleNumber + "', '" + fa.notes + "', '" + fa.howDidYouHear + "', '" + fa.reasonForReferral + "', '" + fa.joinDate.ToString("yyyy-MM-dd") + "', '" + fa.familyType + "', '" + fa.basketType + "', '" + fa.house + "', '" + fa.car + "', '" + fa.debt + "', '" + fa.payChecks + "', '" + fa.bituahLeumi + "', '" + fa.bankAccount + "', '" + fa.creditCard + "', '" + fa.copyId + "', '" + fa.rentContract + "');";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
                MyConn2.Close();
                return rowsNum;
            }
            catch (Exception ex) {
                return rowsNum;
            }
        }


        /// Delete Family
        public static int DeleteFamily(int id)  {
            int rowsNum = 0;
            try  {
                string Query = "DELETE FROM family_tbl WHERE family_Id = " + id + ";";
                MySqlConnection MyConn2 = new MySqlConnection(MySQLCon.conString);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MyConn2.Open();
                rowsNum = MyCommand2.ExecuteNonQuery();     // Here our query will be executed and data saved into the database.  
                MyConn2.Close();
                return rowsNum;
            }
            catch (Exception ex)  {
                return rowsNum = -1;
            }
        }

    }

}

