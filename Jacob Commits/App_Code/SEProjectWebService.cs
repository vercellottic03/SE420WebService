using System;
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

    public SEProjectWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /*
    [WebMethod]
    public void clrSchedule(int sid, int curyear , int curterm)
    {
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string password;

        server = "localhost";
        database = "advise";
        uid = "root";
        password = "jacob";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();


        //Open up a new object of MySqlCommand
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;
        //The following two lines of actual code are the part where I enter my stored procedure name
        //Then specify in the object that it is a stored procedure
        cmd.CommandText = "clrSchedule";
        cmd.CommandType = CommandType.StoredProcedure;
        //The following adds my parameters via implicit conversion
        cmd.Parameters.AddWithValue("sid", sid);
        cmd.Parameters.AddWithValue("curyear", curyear);
        cmd.Parameters.AddWithValue("curterm", curterm);
        //Execute command
        cmd.ExecuteNonQuery();
    }
    */
    /*
    [WebMethod]
    public void delStudent(int sid)
    {
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string password;

        server = "localhost";
        database = "advise";
        uid = "root";
        password = "jacob";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();


        //Open up a new object of MySqlCommand
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;
        //The following two lines of actual code are the part where I enter my stored procedure name
        //Then specify in the object that it is a stored procedure
        cmd.CommandText = "delStudent";
        cmd.CommandType = CommandType.StoredProcedure;
        //The following adds my parameters via implicit conversion
        cmd.Parameters.AddWithValue("sid", sid);
        //Execute command
        cmd.ExecuteNonQuery();
    }

    */

    [WebMethod]
    public List<Advisor> getAdvisor()
    //int choice
    {
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string password;
 
        
        server = "localhost";
        database = "advise";
        uid = "root";
        password = "jacob";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();
        
        //The following is used to select from the database.

        //Open up a new object of MySqlCommand
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;
        //The following two lines of actual code are the part where I enter my stored procedure name
        //Then specify in the object that it is a stored procedure
        //Used remove to test my procedure
        cmd.CommandText = "getAdvisors";
        cmd.CommandType = CommandType.StoredProcedure;
        //The following line is used to utilize user input inside the stored procedure
       


        //List to hold advisor names
        List<Advisor> Test = new List<Advisor>();


        //Create a reader for my cmd
        MySqlDataReader myReader = cmd.ExecuteReader();

        while (myReader.Read())
        {
            //Create student object
            //Have the object creation inside the loop otherwise the prior objects that
            // were inserted into the list will be overwritten by the very last record. 
            Advisor Baxter = new Advisor();
            //Following is used when my variables are private
            Baxter.A_ID = myReader.GetInt32(0);
            Baxter.A_Name = myReader.GetString(1);
            //Can do the following code if the variables are public
            // Baxter.A_Name = myReader.GetString(1);
            Test.Add(Baxter);
            // Convert.GetInt32().MyReader
            // myReader.GetInt32(2);
            //  Test.Add(myReader.GetString(0) + " " + myReader.GetString(1) +
            //  " " + myReader.GetString(2) + " " + myReader.GetString(3));

        }
        //Return String Value
        return Test;

        /*
        The following code is used to return the value in the first row and first column
        object o = cmd.ExecuteScalar();
         string re = o.ToString();
         return re;*/

        //close connection

        //connection.Close();

    }
    
    [WebMethod]
    public List<Course> getCoursesByCode(string ccode)
    //int choice
    {
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string password;



        server = "localhost";
        database = "advise";
        uid = "root";
        password = "jacob";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();

        //The following is used to select from the database.

        //Open up a new object of MySqlCommand
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connection;
        //The following two lines of actual code are the part where I enter my stored procedure name
        //Then specify in the object that it is a stored procedure
        //Used remove to test my procedure
        cmd.CommandText = "getCoursesByCode";
        cmd.CommandType = CommandType.StoredProcedure;
        //The following line is used to utilize user input inside the stored procedure
                //The following adds my parameters via implicit conversion
        cmd.Parameters.AddWithValue("ccode", ccode);


        //List to hold advisor names
        List<Course> Test = new List<Course>();


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
           // Baxter.C_Credit = myReader.GetInt32(3);
            //Can do the following code if the variables are public
            // Baxter.A_Name = myReader.GetString(1);
            Test.Add(Baxter);
            // Convert.GetInt32().MyReader
            // myReader.GetInt32(2);
            //  Test.Add(myReader.GetString(0) + " " + myReader.GetString(1) +
            //  " " + myReader.GetString(2) + " " + myReader.GetString(3));

        }
        //Return String Value
        return Test;

        /*
        The following code is used to return the value in the first row and first column
        object o = cmd.ExecuteScalar();
         string re = o.ToString();
         return re;*/

        //close connection

        //connection.Close();

    }



}
