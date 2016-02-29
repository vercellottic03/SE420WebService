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

   /* public class Advisor
    {
        public int A_ID { get; set; }
        public string A_Name { get; set; }
        public string A_PIN { get; set; }
        public string A_Theme { get; set; }
    }
    */
    [WebMethod]
    public void CreateCard(int courseid, string coursecode, string coursetime, string coursetype, string
      title, string description, int credits, string coursesubtype)
    {
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string password;

        server = "localhost";
        database = "SoftwareEngineeringDB";
        uid = "elizabeth";
        password = "^guesswhoSE420$";
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
        cmd.CommandText = "CreateCard";
        cmd.CommandType = CommandType.StoredProcedure;
        //The following adds my parameters
        //the string is the column name and the second part is either the explicit SqlDbType 
        // or the variable of the value to be used int the query. 
        cmd.Parameters.AddWithValue("courseid", SqlDbType.Int).Value = courseid;
        //The next section of code does not use explicit conversion
        //It uses implicit conversion because I kept getting errors otherwise.
        //The errors were about utilizing the wrong data type which the implicit conversion takes care
        //of. 
        cmd.Parameters.AddWithValue("coursecode", coursecode);
        cmd.Parameters.AddWithValue("coursetime", coursetime);
        cmd.Parameters.AddWithValue("coursetype", coursetype);
        cmd.Parameters.AddWithValue("title", title);
        cmd.Parameters.AddWithValue("description", description);
        //The following line is the only line in this section that uses explicit conversion
        cmd.Parameters.AddWithValue("credits", SqlDbType.Int).Value = credits;
        cmd.Parameters.AddWithValue("coursesubtype", coursesubtype);
        //Execute command
        cmd.ExecuteNonQuery();

    }
    [WebMethod]
    public List<Advisor> getAdvisor()
    //int choice
    {
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string password;
        
       // This was the section of code where I tried to connect to Jon's Server.

         server = "localhost";
        //server = "127.0.0.1";
        //server = "10.240.0.2:3306";
        database = "advise";
        uid = "elizabeth";
        password = "^guesswhoSE420$";
        string connectionString;
        connectionString = "SERVER=" + server + ";PORT=306;" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();
        
        /*
        server = "localhost";
        database = "advise";
        uid = "root";
        password = "jacob";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
        connection.Open();
        */
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
        //  cmd.Parameters.AddWithValue("studentid", SqlDbType.Int).Value = choice;


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
