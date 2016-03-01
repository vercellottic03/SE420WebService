using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Error
/// </summary>
public class Error
{
    public string badConn = "There has been an error connecting to the database, something has gone wrong.";
    public string badInfo = "Incorrect or insufficient data provided, stored procedure not run";
    public Error() {
       
    }
    public string getbadConn()
    {
        return badConn;
    }
    public string getBadInfo()
    {
        return badInfo;
    }
}
