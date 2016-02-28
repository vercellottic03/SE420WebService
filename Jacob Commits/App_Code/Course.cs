using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Course
/// </summary>
public class Course
{
    private int C_ID1;
    private string C_Name1;
    private string C_Code1;
    private int C_Credit1;

    public int C_ID
    {
        get
        {
            return C_ID1;
        }

        set
        {
            C_ID1 = value;
        }
    }

    public string C_Name
    {
        get
        {
            return C_Name1;
        }

        set
        {
            C_Name1 = value;
        }
    }

    public string C_Code
    {
        get
        {
            return C_Code1;
        }

        set
        {
            C_Code1 = value;
        }
    }

    public int C_Credit
    {
        get
        {
            return C_Credit1;
        }

        set
        {
            C_Credit1 = value;
        }
    }
}