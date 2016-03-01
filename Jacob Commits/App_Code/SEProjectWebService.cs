﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;




/// <summary>
/// Summary description for SEProjectWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SEProjectWebService : System.Web.Services.WebService
{
    public static string error = "There has been an error connecting to the database, something has gone wrong.";
    public static string success = "Query successful";
    public SEProjectWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    
    [WebMethod]
    public string clrSchedule(int sid, int curyear , int curterm)
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        string response = success; 
        if (advisorConnect.OpenConnection() == true)
        {

            //Open up a new object of MySqlCommand
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            try {
                cmd.CommandText = "clrSchedule";
                cmd.CommandType = CommandType.StoredProcedure;
                //The following adds my parameters via implicit conversion
                cmd.Parameters.AddWithValue("sid", sid);
                cmd.Parameters.AddWithValue("curyear", curyear);
                cmd.Parameters.AddWithValue("curterm", curterm);
                //Execute command
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                response = ex.ToString();
            }
        }
        else
        {
            response = error; 
        }
        advisorConnect.CloseConnection();
        return response; 
    }
    [WebMethod]
    public string delStudent(int sid)
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        string response = success;
        if (advisorConnect.OpenConnection() == true)
        {

            //Open up a new object of MySqlCommand
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            try
            {
                cmd.CommandText = "delStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                //The following adds my parameters via implicit conversion
                cmd.Parameters.AddWithValue("sid", sid);
                //Execute command
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                response = ex.ToString();
            }
        }
        else
        {
            response = error;
        }
        advisorConnect.CloseConnection();
        return response;
    }

    [WebMethod]
    public List<Advisor> getAdvisor()
    {
        //Creates DBConnect object for this function, establish database connection
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();

        //Open up a new object of MySqlCommand
        List<Advisor> Test = new List<Advisor>();
        if (advisorConnect.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            cmd.CommandText = "getAdvisors";
            cmd.CommandType = CommandType.StoredProcedure;
            //Create a reader for my cmd
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                //Create student object
                //Have the object creation inside the loop otherwise the prior objects that
                //were inserted into the list will be overwritten by the very last record. 
                Advisor Baxter = new Advisor();
                Baxter.A_ID = myReader.GetInt32(0);
                Baxter.A_Name = myReader.GetString(1);
                //Can do the following code if the variables are public
                // Baxter.A_Name = myReader.GetString(1);
                Test.Add(Baxter);
                //Following is used when my variables are private
            }
        }
        else
        {
            Advisor bad = new Advisor();
            bad.Error = error;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List
        return Test;
    }
    [WebMethod]
    public List<Course> getCoursesByCode(string ccode)
    //int choice
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        List<Course> Test = new List<Course>();
        if (advisorConnect.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            //Used remove to test my procedure
            cmd.CommandText = "getCoursesByCode";
            cmd.CommandType = CommandType.StoredProcedure;
            //The following line is used to utilize user input inside the stored procedure
            //The following adds my parameters via implicit conversion
            cmd.Parameters.AddWithValue("ccode", ccode);

            //Create a reader for my cmd
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                //Create student object
                //Have the object creation inside the loop otherwise the prior objects that
                // were inserted into the list will be overwritten by the very last record. 
                Course Baxter = new Course();
                //Following is used when my variables are private
                Baxter.C_ID = myReader.GetInt32(0);
                Baxter.C_Name = myReader.GetString(1);
                Baxter.C_Code = myReader.GetString(2);
                Baxter.C_Credit = myReader.GetInt32(3);
                //Can do the following code if the variables are public
                // Baxter.A_Name = myReader.GetString(1);
                Test.Add(Baxter);
            }
        }
        else
        {
            Course bad = new Course();
            bad.Error = error;
            Test.Add(bad);
        }
            advisorConnect.CloseConnection();
            //Return List Value
            return Test;

    }

    [WebMethod]
    public List<Course> getCoursesByType(string rtype)
    //int choice
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        List<Course> Test = new List<Course>();
        if (advisorConnect.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            //Used remove to test my procedure
            cmd.CommandText = "getCoursesByType";
            cmd.CommandType = CommandType.StoredProcedure;
            //The following line is used to utilize user input inside the stored procedure
            //The following adds my parameters via implicit conversion
            cmd.Parameters.AddWithValue("rtype", rtype);

            //Create a reader for my cmd
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                //Create student object
                //Have the object creation inside the loop otherwise the prior objects that
                // were inserted into the list will be overwritten by the very last record. 
                Course Baxter = new Course();
                //Following is used when my variables are private
                Baxter.C_ID = myReader.GetInt32(0);
                Baxter.C_Name = myReader.GetString(1);
                Baxter.C_Code = myReader.GetString(2);
                Baxter.C_Credit = myReader.GetInt32(3);
                //Can do the following code if the variables are public
                // Baxter.A_Name = myReader.GetString(1);
                Test.Add(Baxter);
            }
        }
        else
        {
            Course bad = new Course();
            bad.Error = error;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;

    }

    [WebMethod]
    public List<Course> getGenEds()
    //int choice
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        List<Course> Test = new List<Course>();
        if (advisorConnect.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            //Used remove to test my procedure
            cmd.CommandText = "getGenEds";
            cmd.CommandType = CommandType.StoredProcedure;
            //The following line is used to utilize user input inside the stored procedure
            //The following adds my parameters via implicit conversion
            

            //Create a reader for my cmd
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                //Create student object
                //Have the object creation inside the loop otherwise the prior objects that
                // were inserted into the list will be overwritten by the very last record. 
                Course Baxter = new Course();
                //Following is used when my variables are private
                Baxter.C_ID = myReader.GetInt32(0);
                Baxter.C_Name = myReader.GetString(1);
                Baxter.C_Code = myReader.GetString(2);
                Baxter.C_Credit = myReader.GetInt32(3);
                //Can do the following code if the variables are public
                // Baxter.A_Name = myReader.GetString(1);
                Test.Add(Baxter);
            }
        }
        else
        {
            Course bad = new Course();
            bad.Error = error;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;

    }

    [WebMethod]
    public List<req> getGenTypes()
    //int choice
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        List<req> Test = new List<req>();
        if (advisorConnect.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            //Used remove to test my procedure
            cmd.CommandText = "getGenTypes";
            cmd.CommandType = CommandType.StoredProcedure;
            //The following line is used to utilize user input inside the stored procedure
            //The following adds my parameters via implicit conversion


            //Create a reader for my cmd
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                //Create student object
                //Have the object creation inside the loop otherwise the prior objects that
                // were inserted into the list will be overwritten by the very last record. 
                req Baxter = new req();
                //Following is used when my variables are private
                Baxter.R_Type = myReader.GetString(0);
                //Can do the following code if the variables are public
                Test.Add(Baxter);
            }
        }
        else
        {
            req bad = new req();
            bad.Error = error;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;
    }

    [WebMethod]
    public List<Major> getMajors()
    //int choice
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        List<Major> Test = new List<Major>();
        if (advisorConnect.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            //Used remove to test my procedure
            cmd.CommandText = "getMajors";
            cmd.CommandType = CommandType.StoredProcedure;
            //The following line is used to utilize user input inside the stored procedure
            //The following adds my parameters via implicit conversion


            //Create a reader for my cmd
            MySqlDataReader myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                //Create student object
                //Have the object creation inside the loop otherwise the prior objects that
                // were inserted into the list will be overwritten by the very last record. 
                Major Baxter = new Major();
                //Following is used when my variables are private
                Baxter.M_ID = myReader.GetInt32(0);
                Baxter.M_Name = myReader.GetString(1);
                Baxter.R_Type = myReader.GetString(2);
                //Can do the following code if the variables are public
                // Baxter.A_Name = myReader.GetString(1);
                Test.Add(Baxter);
            }
        }
        else
        {
            Major bad = new Major();
            bad.Error = error;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;

    }

}
