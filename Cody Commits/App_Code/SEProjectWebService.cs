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
    Error error = new Error();
    //public static string error = "There has been an error connecting to the database, something has gone wrong.";
    public SEProjectWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void CreateCard(int courseid, string coursecode, string coursetime, string coursetype, string
      title, string description, int credits, string coursesubtype)
    {
        /*
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
        */
        DBConnect cardCreate = new DBConnect();
        MySqlConnection createCardConn = cardCreate.getConn();

        //The following is used to select from the database.

        //Open up a new object of MySqlCommand
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = createCardConn;
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
    //This function will be called when an advisor is called from the interface, returns all requested information
    [WebMethod]
    //List<Advisor>
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
                //Following is used when my variables are private
                Baxter.A_ID = myReader.GetInt32(0);
                //Can do the following code if the variables are public
                // Baxter.A_Name = myReader.GetString(1);
                Test.Add(Baxter);
                // Convert.GetInt32().MyReader
                // myReader.GetInt32(2);
                // Test.Add(myReader.GetString(0) + " " + myReader.GetString(1) +
                // " " + myReader.GetString(2) + " " + myReader.GetString(3));
            }
        }  
        else
        {
            Advisor bad = new Advisor();
            bad.A_Name = error.badConn;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List
        return Test;
    }

    [WebMethod]
    public string setMajor(int studentId, int majorId)
    {
        DBConnect setMajDb = new DBConnect();
        MySqlConnection setMajConn = setMajDb.getConn();
        string major;
        if (setMajDb.OpenConnection() == true)
        {
            using (MySqlCommand cmd = new MySqlCommand("setMajor", setMajConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sid", studentId);
                cmd.Parameters.AddWithValue("newMid", majorId);
                major = Convert.ToString(cmd.ExecuteScalar());
            }
            setMajDb.CloseConnection();
            return major;
        }
        else
        {
            setMajDb.CloseConnection();
            return error.badConn;
        }
    }
    [WebMethod]
    public string setAdvisor(int studentId, int newAdvisorId)
    {
        string response;
        DBConnect setNewAdvisorDb = new DBConnect();
        MySqlConnection newAdvisorConn = setNewAdvisorDb.getConn();
        if (setNewAdvisorDb.OpenConnection() == true)
        {
            using (MySqlCommand cmd = new MySqlCommand("setAdvisor", newAdvisorConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("newadv", newAdvisorId);
                cmd.Parameters.AddWithValue("stid", studentId);
                cmd.ExecuteNonQuery();
            }
            response = "query succesful";
            setNewAdvisorDb.CloseConnection();
            return response;
        }
        else
        {
            setNewAdvisorDb.CloseConnection();
            return error.badConn;
        }
        //setNewAdvisorDb.CloseConnection();
        //return response;
    }
    [WebMethod]
    public string putStudent(string sName, int aId, int mId, string sPin, string sTheme)
    {
        string response;
        DBConnect putStuDb = new DBConnect();
        MySqlConnection putStuConn = putStuDb.getConn();
        if(sTheme == "")
        {
            sTheme = "Default";
        } 
        if(sPin == "")
        {
            sPin = "0000";
        }
        if (putStuDb.OpenConnection() == true)
        {
            using(MySqlCommand cmd = new MySqlCommand("putStudent", putStuConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sname", sName);
                cmd.Parameters.AddWithValue("aid", aId);
                cmd.Parameters.AddWithValue("mid", mId);
                cmd.Parameters.AddWithValue("spin", sPin);
                cmd.Parameters.AddWithValue("stheme", sTheme);
                cmd.ExecuteNonQuery();
            }
            response = "query succesful";
            putStuDb.CloseConnection();
            return response;
        }
        else
        {
            putStuDb.CloseConnection();
            return error.badConn;
        }

    }
    [WebMethod]
    public string putSchedule(int courseId, int studentId, int scheduleYear, int scheduleTerm)
    {
        DBConnect putSchedDB = new DBConnect();
        MySqlConnection putSchedConn = putSchedDB.getConn();
        string response;
        if (courseId == 0 || studentId == 0 || scheduleTerm == 0 || scheduleYear == 0)
        {
            return error.badInfo;
        }
        if (putSchedDB.OpenConnection() == true)
        {
            using(MySqlCommand cmd = new MySqlCommand("putSchedule", putSchedConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("cid", courseId);
                cmd.Parameters.AddWithValue("sid", studentId);
                cmd.Parameters.AddWithValue("schyear", scheduleYear);
                cmd.Parameters.AddWithValue("schterm", scheduleTerm);
                cmd.ExecuteNonQuery();
            }
            response = "query successful";
            putSchedDB.CloseConnection();
            return response;
        }
        else
        {
            putSchedDB.CloseConnection();
            return error.badConn;
        }
        //putSchedDB.CloseConnection();
        //return response;
    }
}
