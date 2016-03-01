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
    public string clrSchedule(int sid, int curyear, int curterm)
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        string response = "There has been an error connecting to the database, something has gone wrong.";
        if (advisorConnect.OpenConnection() == true)
        {

            //Open up a new object of MySqlCommand
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = adconn;
            //The following two lines of actual code are the part where I enter my stored procedure name
            //Then specify in the object that it is a stored procedure
            try
            {
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
            response = "Query successful";
        }
        advisorConnect.CloseConnection();
        return response;
    }

    [WebMethod]
    public string delStudent(int sid)
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        string response = "Query successful";
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
            response = "There has been an error connecting to the database, something has gone wrong.";
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
            bad.A_Name = error.badConn;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List
        return Test;
    }

<<<<<<< HEAD
=======
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
            bad.Error = "There has been an error connecting to the database, something has gone wrong.";
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
            bad.Error = "There has been an error connecting to the database, something has gone wrong.";
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;

    }

    [WebMethod]
    public List<Req> getGenTypes()
    //int choice
    {
        DBConnect advisorConnect = new DBConnect();
        MySqlConnection adconn = advisorConnect.getConn();
        List<Req> Test = new List<Req>();
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
                Req Baxter = new Req();
                //Following is used when my variables are private
                Baxter.R_Type = myReader.GetString(0);
                //Can do the following code if the variables are public
                Test.Add(Baxter);
            }
        }
        else
        {
            Req bad = new Req();
            bad.Error = "There has been an error connecting to the database, something has gone wrong.";
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;
    }

>>>>>>> c894df0d93ca506de1674fce74a54035714b82e4
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
            bad.Error = "There has been an error connecting to the database, something has gone wrong.";
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;

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
        if (putStuDb.OpenConnection() == true)
        {
            using (MySqlCommand cmd = new MySqlCommand("putStudent", putStuConn))
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
    public object putSchedule(int courseId, int studentId, int scheduleYear, int scheduleTerm)
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
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("putSchedule", putSchedConn))
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
            catch (MySqlException ex)
            {
                response = Convert.ToString(ex);
                putSchedDB.CloseConnection();
                return response;
            }
        }
        else
        {
            putSchedDB.CloseConnection();
            return error.badConn;
        }
        //putSchedDB.CloseConnection();
        //return response;
    }
    [WebMethod]
    public List<Student> getStudentsByAdvisor(int aId)
    {
        DBConnect getStuAdDb = new DBConnect();
        MySqlConnection getStuAdConn = getStuAdDb.getConn();
        List<Student> S = new List<Student>();
        if (getStuAdDb.OpenConnection() == true)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("getStudentsByAdvisor", getStuAdConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("aid", aId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Student i = new Student();
                        i.Stu_ID = reader.GetInt32(0);
                        i.Stu_Name = reader.GetString(1);
                        i.M_ID = reader.GetInt32(2);
                        i.m_Name = reader.GetString(3);
                        S.Add(i);
                    }
                    getStuAdDb.CloseConnection();
                    return S;
                }
            }
            catch (MySqlException ex)
            {
                Student bad = new Student();
                bad.Error = Convert.ToString(ex);
                S.Add(bad);
                getStuAdDb.CloseConnection();
                return S;
            }
        }
        else
        {
            Student bad = new Student();
            bad.Error = error.badConn;
            S.Add(bad);
            getStuAdDb.CloseConnection();
            return S;
        }
    }
    [WebMethod]
    public List<Schedule> getSchedBySIDForStudent(int sid, string spin)
    {
        DBConnect schedForStudDb = new DBConnect();
        MySqlConnection schedForStudConn = schedForStudDb.getConn();
        List<Schedule> S = new List<Schedule>();
        if (schedForStudDb.OpenConnection() == true)
        {
            using (MySqlCommand cmd = new MySqlCommand("getSchedBySIDForStudent", schedForStudConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sid", sid);
                cmd.Parameters.AddWithValue("spin", spin);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Schedule g = new Schedule();
                        g.C_name = reader.GetString(0);
                        g.C_code = reader.GetString(1);
                        g.C_credits = reader.GetInt32(2);
                        g.S_term = reader.GetInt32(3);
                        g.S_year = reader.GetInt32(4);
                        S.Add(g);
                    }
                    schedForStudDb.CloseConnection();
                    return S;
                }
                else
                {
                    Schedule bad = new Schedule();
                    bad.Error = error.badInfo;
                    S.Add(bad);
                    schedForStudDb.CloseConnection();
                    return S;
                }
            }
        }
        else
        {
            Schedule bad = new Schedule();
            bad.Error = error.badConn;
            S.Add(bad);
            schedForStudDb.CloseConnection();
            return S;
        }
    }

    [WebMethod]
    public List<Schedule> getSchedBySIDForAdvis(int sid, int aid, string apin)
    {
        DBConnect getSchedAdDB = new DBConnect();
        MySqlConnection getSchedAdConn = getSchedAdDB.getConn();
        List<Schedule> S = new List<Schedule>();
        if (getSchedAdDB.OpenConnection())
        {
            using (MySqlCommand cmd = new MySqlCommand("getSchedBySIDForAdvisor", getSchedAdConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sid", sid);
                cmd.Parameters.AddWithValue("aid", aid);
                cmd.Parameters.AddWithValue("apin", apin);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Schedule g = new Schedule();
                        g.C_name = reader.GetString(0);
                        g.C_code = reader.GetString(1);
                        g.C_credits = reader.GetInt32(2);
                        g.S_term = reader.GetInt32(3);
                        g.S_year = reader.GetInt32(4);
                        S.Add(g);
                    }
                    getSchedAdDB.CloseConnection();
                    return S;
                }
                else
                {
                    Schedule bad = new Schedule();
                    bad.Error = error.badInfo;
                    S.Add(bad);
                    getSchedAdDB.CloseConnection();
                    return S;
                }
            }
        }
        else
        {
            Schedule bad = new Schedule();
            bad.Error = error.badConn;
            S.Add(bad);
            getSchedAdDB.CloseConnection();
            return S;
        }
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


            //List to hold advisor names



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
            bad.Error = error.badConn;
            Test.Add(bad);
        }
        advisorConnect.CloseConnection();
        //Return List Value
        return Test;

    }
}